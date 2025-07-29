using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelInfoDisplay : MonoBehaviour
{
    public Image background;
    public Image icon;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public void SetInfo(Sprite bg, Sprite ic, string title, string desc)
    {
        background.sprite = bg;
        icon.sprite = ic;
        titleText.text = title;
        descriptionText.text = desc;
    }
}
