
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public string nombreMapa = "Mapa";
    public string nombreMenu = "MenuPrincipal";

    void Start()
    {
        Time.timeScale = 1f;
        panelGameOver.SetActive(false);
    }

    public void MostrarGameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reintentar()
    {
        // Ocultar Game Over y reiniciar el nivel actual
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void IrAlMapa()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreMapa);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreMenu);
    }
}