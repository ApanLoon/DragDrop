using Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UIDropTarget StartDropTarget { get; private set; }
    private UIDropTarget _endDropTarget;
    
    private RawImage  _image;

    public void SetEndDropTarget (UIDropTarget target)
    {
        _endDropTarget = target;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartDropTarget = transform.parent.GetComponent<UIDropTarget>();

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        var startdropTarget = StartDropTarget.GetComponent<UIDropTarget>();
        startdropTarget.RaiseOnRemoved(this);

        _image = GetComponent<RawImage>();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_endDropTarget == null)
        {
            _endDropTarget = StartDropTarget;
        }

        transform.SetParent(_endDropTarget.transform);
        _endDropTarget.RaiseOnDropped(this);
        _image.raycastTarget = true;
        _image = null;
    }
}
