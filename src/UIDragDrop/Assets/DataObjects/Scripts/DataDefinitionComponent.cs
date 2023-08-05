using System;
using UnityEngine;

namespace DataObjects
{
    /// <summary>
    /// A DataDefinitionComponent is a component that can be added to a DataDefinitionObject.
    /// 
    /// NOTE: If a DataComponent subclass has no serializable fields, the component will not be saved.
    /// </summary>
    [Serializable] public class DataDefinitionComponent
    {
        /// <summary>
        /// The DataDefinitionObject this component is attached to.
        /// </summary>
        public DataDefinitionObject DataDefinitionObject => _dataDefinitionObject;
        [SerializeField, HideInInspector] private DataDefinitionObject _dataDefinitionObject;



        /// <summary>
        /// This should only be called from DataDefinitionObject.AddComponent
        /// </summary>
        /// <param name="dataDefinitionObject"></param>
        internal void SetDataDefinitionObject(DataDefinitionObject dataDefinitionObject)
        {
            _dataDefinitionObject = dataDefinitionObject;
        }
    }
}
