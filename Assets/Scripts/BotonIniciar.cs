using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonIniciar : MonoBehaviour
{
    public Button botonIniciar;

    public string nombreEscena;

    public void IniciarJuego()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}