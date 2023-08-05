using DataObjects;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items
{
    public class UIDropTarget : MonoBehaviour, IDropHandler
    {

        public event Action<UIDraggable, UIDropTarget> OnDropped;
        public void RaiseOnDropped(UIDraggable draggable)
        {
            OnDropped?.Invoke(draggable, this);
        }

        public event Action<UIDraggable, UIDropTarget> OnRemoved;
        public void RaiseOnRemoved(UIDraggable draggable)
        {
            OnRemoved?.Invoke(draggable, this);
        }

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

            draggable.SetEndDropTarget (GetDropTarget(dropGo, draggable));

        }

        private UIDropTarget GetDropTarget(GameObject dropGo, UIDraggable draggable)
        { 
            var dropItem = dropGo.GetComponent<UIItemIcon>();
            if (dropItem == null)
            {
                return null;
            }

            // Check if this slot accepts the type of item being dropped:
            foreach ( var validator in GetComponents<UIDropValidator>())
            {
                if (validator.IsDropAllowed(draggable, this) == false)
                {
                    return null;
                }
            }

            // Check if there is already an item in this slot:
            if (transform.childCount != 0)
            {
                var oldGo = transform.GetChild(0);
                var oldItem = oldGo.GetComponent<UIItemIcon>();

                if (oldItem == null)
                {
                    Debug.LogError($"Item in {gameObject.name} ({oldGo.name}) doesn't have an UIItemIcon component!");
                    return null;
                }

                if (oldItem.Definition != dropItem.Definition)
                {
                    // Swap items of different type:
                    oldGo.transform.SetParent(draggable.StartDropTarget.transform);
                    return this;
                }

                if (oldItem.Definition is DataDefinitionObject definition)
                {
                    var inventoryItem = oldItem.Definition.GetComponent<InventoryItem>();
                    if (inventoryItem == null || oldItem.StackSize >= inventoryItem.MaxStackSize)
                    {
                        return null;
                    }
                    oldItem.StackSize += dropItem.StackSize;
                    Destroy(dropGo); // Stacks are merged, delete.
                    return null;
                }
            }

            return this;
        }
    }
}
