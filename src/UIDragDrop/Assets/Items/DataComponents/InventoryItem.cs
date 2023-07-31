using DataObjects;
using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class InventoryItem : DataComponent
    {
        /// <summary>
        /// Defines how many can be stacked in an inventory slot.
        /// </summary>
        public int MaxStackSize = 1;

        /// <summary>
        /// Base price for buying or selling. Trader percentages are added to this.
        /// </summary>
        public int BasePrice = 1;
    }
}

