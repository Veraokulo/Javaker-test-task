using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Placeholder.Instance.OnEnterDropZone(transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Placeholder.Instance.OnLeftDropZone(transform);
    }
}