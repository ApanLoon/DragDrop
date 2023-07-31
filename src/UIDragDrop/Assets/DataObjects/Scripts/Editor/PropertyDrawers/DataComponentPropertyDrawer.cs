using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DataObjects
{
    [CustomPropertyDrawer(typeof(DataComponent))]
    public class DataComponentPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var dataComponent = property.boxedValue;

            VisualElement root = new VisualElement();
            root.Bind(property.serializedObject);

            root.Add(new PropertyField(property, dataComponent.GetType().FullName));

            return root;
        }
    }
}

