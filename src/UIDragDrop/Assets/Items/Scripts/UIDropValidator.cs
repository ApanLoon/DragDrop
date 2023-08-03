using Items;
using UnityEngine;

public class UIDropValidator : MonoBehaviour
{
    public virtual bool IsDropAllowed(UIDraggable draggable, UIDropTarget uIDropTarget)
    {
        return true;
    }
}
