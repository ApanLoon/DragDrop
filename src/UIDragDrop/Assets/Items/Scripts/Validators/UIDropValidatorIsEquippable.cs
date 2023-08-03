namespace Items
{
    public class UIDropValidatorIsEquippable : UIDropValidator
    {
        public string Slot;

        public override bool IsDropAllowed(UIDraggable draggable, UIDropTarget uIDropTarget)
        {
            var itemIcon = draggable.GetComponent<UIItemIcon>();
            if (itemIcon == null || itemIcon.Definition == null)
            {
                return false;
            }

            var equipable = itemIcon.Definition.GetComponent<Equipable>();
            if (equipable == null)
            {
                return false;
            }

            return equipable.Slot == Slot;
        }
    }
}
