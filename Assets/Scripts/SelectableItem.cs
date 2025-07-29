using UnityEngine;
using UnityEngine.UI;

public class SelectableItem : MonoBehaviour
{
    public Sprite panelBackground;
    public Sprite panelIcon;
    public string panelTitle;
    [TextArea] public string panelDescription;

    public GameObject panelPrefab; // Prefab del panel
    public Transform panelParent;  // Canvas o lugar donde se instancia

    public void ShowPanel()
    {
        GameObject panelInstance = Instantiate(panelPrefab, panelParent);
        PanelInfoDisplay info = panelInstance.GetComponent<PanelInfoDisplay>();
        panelInstance.SetActive(true);
        info.SetInfo(panelBackground, panelIcon, panelTitle, panelDescription);
    }
}
