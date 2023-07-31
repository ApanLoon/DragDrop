
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DataObjects
{
    [CustomEditor(typeof(DataObject))]
    [CanEditMultipleObjects]
    public class DataObjectEditor : Editor
    {
        private SerializedProperty _dataObject;
        private bool _showAddComponent = false;

        private static Dictionary<Type, Type> _dataCompomentEditorTypeByType = new Dictionary<Type, Type>();

        private DataComponentEditor CreateDataComponentEditor (DataComponent component)
        {
            var componentType = component.GetType();
            if (!_dataCompomentEditorTypeByType.ContainsKey(componentType))
            {
                var editorType = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(assembly => assembly.GetTypes())
                        .FirstOrDefault(type =>
                        {
                            if (!type.IsSubclassOf(typeof(DataComponentEditor)))
                            {
                                return false;
                            }

                            var typeInfo = type.GetTypeInfo();
                            var attributes = typeInfo.GetCustomAttributes();
                            var attribute = (DataComponentEditorAttribute)attributes.FirstOrDefault(x => x is DataComponentEditorAttribute);
                            if (attribute == null)
                            {
                                return false;
                            }

                            if (attribute.For != componentType)
                            {
                                return false;
                            }
                            return true;
                        });

                if (editorType == null)
                {
                    editorType = typeof (DataComponentEditor);
                }

                _dataCompomentEditorTypeByType[componentType] = editorType;
                //Debug.Log($"Added editor ({editorType.Name}) for {componentType.Name}.");
            }

            var editor = (DataComponentEditor)Activator.CreateInstance (_dataCompomentEditorTypeByType[component.GetType()]);
            editor.target = component;
            return editor;
        }

        private void OnEnable()
        {
            _dataObject = serializedObject.FindProperty("DataObject");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            base.OnInspectorGUI();

            var dataObject = (DataObject)target;
            foreach (var component in dataObject.Components)
            {
                EditorGUILayout.LabelField($"DataObjectEditor, component: {component}");
                var componentEditor = CreateDataComponentEditor(component);
                if (componentEditor == null)
                {
                    Debug.LogError($"No editor for {component}");
                }
                else
                {
                    componentEditor.OnInspectorGUI();
                }
            }

            if (GUILayout.Button("Add component")) // TODO: How do I make a popup here instead?
            {
                _showAddComponent = !_showAddComponent;
            }

            if (_showAddComponent)
            {
                var componentTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => type.IsSubclassOf(typeof(DataComponent)))
                    .Select(type => type).ToList();

                using (new EditorGUILayout.VerticalScope())
                {
                    foreach (var componentType in componentTypes)
                    {
                        if (GUILayout.Button(componentType.Name))
                        {
                            var component = (DataComponent)Activator.CreateInstance(componentType);
                            if (component != null)
                            {
                                dataObject.AddComponent(component);
                            }
                            else
                            {
                                Debug.LogError($"Unable to create instance of {componentType.Name} in {dataObject}.");
                            }
                            _showAddComponent = false;
                        }
                    }
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
