using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{

    public string nombreEscena;

    public void SwapScene()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}