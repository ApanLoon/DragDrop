namespace Items
{
    public class UIDropValidatorIsInventoryItem: UIDropValidator
    {
        public override bool IsDropAllowed(UIDraggable draggable, UIDropTarget uIDropTarget)
        {
            var itemIcon = draggable.GetComponent<UIItemIcon>();
            if (itemIcon == null || itemIcon.Definition == null)
            {
                return false;
            }

            return itemIcon.Definition.GetComponent<InventoryItem>() != null;
        }
    }
}
