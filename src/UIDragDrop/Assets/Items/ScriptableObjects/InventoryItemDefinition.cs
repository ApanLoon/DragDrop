using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Item definitions/Inventory", fileName = "New Inventory")]
    public class InventoryItemDefinition : ItemDefinition
    {
        /// <summary>
        /// Defines how many can be stacked in an inventory slot.
        /// </summary>
        public int stackMax = 1;

        /// <summary>
        /// Base price for buying or selling. Trader percentages are added to this.
        /// </summary>
        public int basePrice = 1;
    }
}
