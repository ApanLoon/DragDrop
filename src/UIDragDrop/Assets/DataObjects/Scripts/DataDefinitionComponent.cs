using System;

namespace DataObjects
{
    [Serializable]
    public class DataDefinitionComponent
    {
        public DataDefinitionObject DataDefinitionObject { get;  set; }

        // NOTE: If a DataComponent subclass has no serializable fields, the component will not be saved.

        /// <summary>
        /// This should only be called from DataDefinitionObject.AddComponent
        /// </summary>
        /// <param name="dataDefinitionObject"></param>
        public void SetDataDefinitionObject(DataDefinitionObject dataDefinitionObject)
        {
            this.DataDefinitionObject = dataDefinitionObject;
        }
    }
}
