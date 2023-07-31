using DataObjects;
using System;

namespace Items
{
    [Serializable]
    public class Equipable : DataComponent
    {
        public string Slot;
    }
}
