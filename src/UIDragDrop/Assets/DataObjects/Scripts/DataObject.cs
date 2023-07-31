using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataObjects
{
    /// <summary>
    /// A ScriptableObject that supports a component model where you can add DataComponents.
    /// </summary>
    [CreateAssetMenu()]
    public class DataObject : ScriptableObject
    {
        public string Name;
        public List<DataComponent> Components = new List<DataComponent>();

        public T GetComponent<T>() where T: DataComponent
        {
            return (T)Components.FirstOrDefault(x => x is T);
        }

        public void AddComponent (DataComponent component)
        {
            Components.Add(component);
        }
        public void RemoveComponent(DataComponent component)
        {
            Components.Remove(component);
        }
    }
}

