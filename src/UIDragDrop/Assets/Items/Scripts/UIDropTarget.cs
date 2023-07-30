using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class UIDropTarget : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            var dropGo = eventData.pointerDrag;
            if (dropGo == null)
            {
                return;
            }

            var draggable = dropGo.GetComponent<UIDraggable>();
            if (draggable == null)
            {
                return;
            }

            var dropItem = dropGo.GetComponent<UIItemIcon>();
            if (dropItem == null)
            {
                return;
            }

            // Check if we can drop here:

            // TODO: Check if this slot accepts the type of item being dropped.

            // Check if there is already an item in this slot:
            if (transform.childCount != 0)
            {
                var oldGo = transform.GetChild(0);
                var oldItem = oldGo.GetComponent<UIItemIcon>();

                if (oldItem == null)
                {
                    Debug.LogError($"Item in {gameObject.name} ({oldGo.name}) doesn't have an UIItemIcon component!");
                    return;
                }

                if (oldItem.Definition != dropItem.Definition)
                {
                    // Swap items of different type:
                    oldGo.transform.SetParent(draggable.StartParent);
                    draggable.SetDropTarget(transform); // TODO: Couldn't we just set the transform directly here?
                    return;
                }

                if (oldItem.Definition is InventoryItemDefinition definition)
                {
                    if (oldItem.StackSize >= definition.stackMax)
                    {
                        return;
                    }
                    oldItem.StackSize += dropItem.StackSize;
                    Destroy(dropGo); // Stacks are merged, delete.
                    return;
                }
            }

            draggable.SetDropTarget(transform); // TODO: Couldn't we just set the transform directly here?
        }
    }
}
