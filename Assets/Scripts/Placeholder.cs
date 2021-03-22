using UnityEngine;

public class Placeholder : MonoBehaviour
{
    public static Placeholder Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OnEnterDropZone(Transform dropZoneTransform)
    {
        gameObject.SetActive(true);
        transform.SetParent(dropZoneTransform);
    }

    public void UpdateSiblingIndex(Vector3 position)
    {
        if (!gameObject.activeSelf) return;

        for (var i = 0; i <= transform.parent.childCount; ++i)
        {
            if (i == transform.parent.childCount)
            {
                transform.SetSiblingIndex(i);
                break;
            }

            if (transform.parent.GetChild(i).position.x > position.x)
            {
                transform.SetSiblingIndex(transform.GetSiblingIndex() < i ? i - 1 : i);
                break;
            }
        }
    }

    public void OnLeftDropZone(Transform dropZoneTransform)
    {
        transform.SetParent(dropZoneTransform.parent);
        gameObject.SetActive(false);
    }
}