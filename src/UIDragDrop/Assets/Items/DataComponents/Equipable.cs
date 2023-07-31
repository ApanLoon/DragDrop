using DataObjects;
using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class Equipable : DataComponent
    {
        public string Slot;
    }
}
