using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace DataObjects
{
    [CustomEditor(typeof(DataObject))]
    public class DataObjectEditor : Editor
    {
        private static Type[] AvailableComponentTypes;

        private PropertyField _componentsField;
        private Box _availableComponentsBox;

        public DataObjectEditor()
        {
            if (AvailableComponentTypes == null)
            {
                AvailableComponentTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => type.IsSubclassOf(typeof(DataComponent)))
                    .ToArray();
            }
        }


        public override VisualElement CreateInspectorGUI()
        {
            DataObject dataObject = (DataObject)target;
            var componentsProperty = serializedObject.FindProperty("Components");

            VisualElement root = new VisualElement();

            _componentsField = new PropertyField(componentsProperty);
            root.Add(_componentsField);

            _availableComponentsBox = new Box();
            _availableComponentsBox.visible = false;
            root.Add(_availableComponentsBox);

            foreach (var componentType in AvailableComponentTypes)
            {
                var button = new Button(() =>
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
                    _availableComponentsBox.visible = false;
                });

                button.text = componentType.Name;
                _availableComponentsBox.Add(button);
            }

            // Override the Add button in the components list view:
            _componentsField.RegisterCallback<GeometryChangedEvent>(OverrideComponentsListViewAdd);

            return root;
        }

        private void OverrideComponentsListViewAdd(GeometryChangedEvent e)
        {
            _componentsField.UnregisterCallback<GeometryChangedEvent>(OverrideComponentsListViewAdd);

            var addComponentButton = _componentsField.Query<Button>("unity-list-view__add-button").Build().Last();
            addComponentButton.clickable = new Clickable(() => _availableComponentsBox.visible = !_availableComponentsBox.visible);
        }
    }
}
