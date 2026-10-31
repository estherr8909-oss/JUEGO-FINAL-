using UnityEngine;
using UnityEngine.SceneManagement;

public class AbriraJutes : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Mapa");
    }

    public void VolverInicio()
    {
        SceneManager.LoadScene("");
    }
}