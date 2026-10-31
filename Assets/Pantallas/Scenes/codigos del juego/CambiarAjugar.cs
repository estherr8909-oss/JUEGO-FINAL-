using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarAjugar : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Mapa");
    }

    public void VolverInicio()
    {
        SceneManager.LoadScene("Menu");
    }
}