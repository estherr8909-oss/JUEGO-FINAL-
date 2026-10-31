using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Mapa");
    }
}