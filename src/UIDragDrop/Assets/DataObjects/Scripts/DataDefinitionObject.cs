using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataObjects
{
    /// <summary>
    /// A ScriptableObject that supports a component model where you can add DataComponents.
    /// </summary>
    [CreateAssetMenu()]
    public class DataDefinitionObject : ScriptableObject
    {
        public string Name;

        [SerializeReference] public List<DataDefinitionComponent> Components = new List<DataDefinitionComponent>();

        public T GetComponent<T>() where T: DataDefinitionComponent
        {
            return (T)Components.FirstOrDefault(x => x is T);
        }

        public void AddComponent (DataDefinitionComponent component)
        {
            Components.Add(component);
            component.SetDataDefinitionObject(this);
        }
        public void RemoveComponent(DataDefinitionComponent component)
        {
            Components.Remove(component);
            component.SetDataDefinitionObject(null);
        }
    }
}

