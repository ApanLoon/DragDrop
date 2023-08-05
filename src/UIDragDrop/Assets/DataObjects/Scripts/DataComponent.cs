
namespace DataObjects
{
    public class DataComponent
    {
        public DataObject DataObject { get; private set; }

        /// <summary>
        /// This should only be called from DataObject.AddComponent
        /// </summary>
        /// <param name="dataObject"></param>
        public void SetDataObject (DataObject dataObject)
        {
            this.DataObject = dataObject;
        }
    }
}

