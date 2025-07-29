using UnityEngine;
using UnityEngine.EventSystems;

public class HidePanel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
