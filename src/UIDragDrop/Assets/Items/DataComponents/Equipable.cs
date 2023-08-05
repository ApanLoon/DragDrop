using DataObjects;
using System;

namespace Items
{
    [Serializable]
    public class Equipable : DataDefinitionComponent
    {
        public string Slot;
    }
}
