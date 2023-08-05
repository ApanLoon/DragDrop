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

        /// <summary>
        /// Get the first component of type T or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T: DataDefinitionComponent
        {
            return (T)Components.FirstOrDefault(x => x is T);
        }

        /// <summary>
        /// Adds a new component to this object.
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent (DataDefinitionComponent component)
        {
            Components.Add(component);
            component.SetDataDefinitionObject(this);
        }

        /// <summary>
        /// Removes the given component from this object.
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(DataDefinitionComponent component)
        {
            Components.Remove(component);
            component.SetDataDefinitionObject(null);
        }
    }
}

