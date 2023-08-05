using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataObjects
{
    public class DataObject
    {
        [SerializeReference] public List<DataComponent> Components = new List<DataComponent>();

        public T GetComponent<T>() where T : DataComponent
        {
            return (T)Components.FirstOrDefault(x => x is T);
        }

        public void AddComponent(DataComponent component)
        {
            Components.Add(component);
            component.SetDataObject(this);
        }
        public void RemoveComponent(DataComponent component)
        {
            Components.Remove(component);
            component.SetDataObject(null);
        }
    }
}

