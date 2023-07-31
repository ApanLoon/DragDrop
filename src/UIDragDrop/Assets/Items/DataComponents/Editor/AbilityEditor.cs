using DataObjects;
using UnityEditor;
using UnityEngine;

namespace Items
{
    [DataComponentEditor(For = typeof(Ability))]
    public class AbilityEditor : DataComponentEditor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField($"AbilityEditor, target: {target}");
        }
    }
}
