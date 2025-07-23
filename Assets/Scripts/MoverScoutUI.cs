using UnityEngine;

public class MoverScoutUI : MonoBehaviour
{
    public RectTransform scout;      // Scout debe ser parte del Canvas (UI)
    public RectTransform targetStage; // Se define en tiempo de ejecución desde el botón
    public float speed = 5f;

    private bool mover = false;

    void Update()
    {
        if (mover && targetStage != null)
        {
            scout.anchoredPosition = Vector2.MoveTowards(
                scout.anchoredPosition,
                targetStage.anchoredPosition,
                speed * Time.deltaTime
            );

            if (Vector2.Distance(scout.anchoredPosition, targetStage.anchoredPosition) < 1f)
            {
                mover = false;
            }
        }
    }

    // Método público que se llama desde el botón
    public void MoverScout(RectTransform stageBtn)
    {
        targetStage = stageBtn;
        mover = true;
    }
}
