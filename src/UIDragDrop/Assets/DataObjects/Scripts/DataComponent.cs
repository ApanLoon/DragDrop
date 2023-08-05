
namespace DataObjects
{
    public class DataComponent
    {
        /// <summary>
        /// The DataObject this component is attached to.
        /// </summary>
        public DataObject DataObject { get; private set; }

        /// <summary>
        /// This should only be called from DataObject.AddComponent
        /// </summary>
        /// <param name="dataObject"></param>
        internal void SetDataObject (DataObject dataObject)
        {
            DataObject = dataObject;
        }
    }
}

