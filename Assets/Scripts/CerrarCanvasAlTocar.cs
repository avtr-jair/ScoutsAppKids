using UnityEngine;
using UnityEngine.EventSystems;

public class CerrarCanvasAlTocar : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvasRaiz; // referencia al GameObject del Canvas

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canvasRaiz != null)
        {
            canvasRaiz.SetActive(false);
        }
    }
}
