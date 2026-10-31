
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesNivel : MonoBehaviour
{
    public void IrAlSiguienteNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel 2");
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}