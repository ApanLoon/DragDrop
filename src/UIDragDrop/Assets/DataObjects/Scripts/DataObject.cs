using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataObjects
{
    public class DataObject
    {
        [SerializeReference] public List<DataComponent> Components = new List<DataComponent>();

        /// <summary>
        /// Returns the first component of type T or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : DataComponent
        {
            return (T)Components.FirstOrDefault(x => x is T);
        }

        /// <summary>
        /// Adds a new component to this object.
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(DataComponent component)
        {
            Components.Add(component);
            component.SetDataObject(this);
        }

        /// <summary>
        /// Removes the given component from this object.
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(DataComponent component)
        {
            Components.Remove(component);
            component.SetDataObject(null);
        }
    }
}

