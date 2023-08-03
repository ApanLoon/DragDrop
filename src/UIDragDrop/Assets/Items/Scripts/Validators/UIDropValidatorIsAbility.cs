namespace Items
{
    public class UIDropValidatorIsAbility : UIDropValidator
    {
        public override bool IsDropAllowed(UIDraggable draggable, UIDropTarget uIDropTarget)
        {
            var itemIcon = draggable.GetComponent<UIItemIcon>();
            if (itemIcon == null || itemIcon.Definition == null)
            {
                return false;
            }

            return itemIcon.Definition.GetComponent<Ability>() != null;
        }
    }
}
