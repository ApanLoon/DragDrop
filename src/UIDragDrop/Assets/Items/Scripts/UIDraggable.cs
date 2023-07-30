using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform StartParent { get; private set; }
    private Transform _dropTarget;
    private RawImage  _image;

    public void SetDropTarget (Transform target)
    {
        _dropTarget = target;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartParent = transform.parent;
        
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        _image = GetComponent<RawImage>();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_dropTarget != null ? _dropTarget : StartParent);
        _image.raycastTarget = true;
        _image = null;
    }
}
