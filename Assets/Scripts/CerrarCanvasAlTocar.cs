using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CerrarCanvasAlTocar : MonoBehaviour, IPointerClickHandler
{
    public GameObject panelDialogo;             // El Panel que quieres ocultar
    public Animator anim1;
    public Animator anim2;

    public string boolParam1 = "Salir";
    public string boolParam2 = "Salir";
    public float fadeDuration = 0.5f;           // Duración del fade-out

    private CanvasGroup canvasGroup;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(EjecutarAnimacionesYFade());
    }

    private IEnumerator EjecutarAnimacionesYFade()
    {
        if (anim1 != null)
            anim1.SetBool(boolParam1, true);

        if (anim2 != null)
            anim2.SetBool(boolParam2, true);

        yield return new WaitForSeconds(1f); // Esperar que terminen las animaciones (ajustar)

        if (anim1 != null)
            anim1.SetBool(boolParam1, false);

        if (anim2 != null)
            anim2.SetBool(boolParam2, false);

        // Obtener el CanvasGroup del panel
        if (canvasGroup == null)
            canvasGroup = panelDialogo.GetComponent<CanvasGroup>();

        if (canvasGroup != null)
        {
            float t = 0;
            float startAlpha = canvasGroup.alpha;

            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, t / fadeDuration);
                yield return null;
            }

            canvasGroup.alpha = 0;
        }

        // Ocultar el panel completamente
        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }
}
