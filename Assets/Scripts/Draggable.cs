using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup _canvasGroup;
    private Transform _parentToReturnTo;
    private int _siblingIndexBeforeDrag;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        
        _parentToReturnTo = transform.parent;
        _siblingIndexBeforeDrag = transform.GetSiblingIndex();
        
        Placeholder.Instance.OnEnterDropZone(_parentToReturnTo);
        
        transform.SetParent(transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Placeholder.Instance.UpdateSiblingIndex(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Placeholder.Instance.gameObject.activeSelf)
        {
            transform.SetParent(Placeholder.Instance.transform.parent);
            transform.SetSiblingIndex(Placeholder.Instance.transform.GetSiblingIndex());
            Placeholder.Instance.OnLeftDropZone(_parentToReturnTo);
        }
        else
        {
            transform.SetParent(_parentToReturnTo);
            transform.SetSiblingIndex(_siblingIndexBeforeDrag);
        }

        _canvasGroup.blocksRaycasts = true;
    }
}