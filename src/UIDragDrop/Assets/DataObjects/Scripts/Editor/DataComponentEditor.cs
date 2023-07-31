using UnityEngine;
using UnityEditor;

namespace DataObjects
{
    [DataComponentEditor(For = typeof(DataComponent))]
    public class DataComponentEditor
    {
        public DataComponent target;

        public virtual void OnInspectorGUI()
        {
            EditorGUILayout.LabelField($"DataComponentEditor, target: {target}");
        }
    }
}
