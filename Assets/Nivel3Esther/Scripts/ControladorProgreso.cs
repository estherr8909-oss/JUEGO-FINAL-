using UnityEngine;
using UnityEngine.SceneManagement; // Obligatorio para cambiar de escena

namespace Nivel3Esther
{
    public class ControladorProgreso : MonoBehaviour
    {
        // ... Tus variables de los paneles aquí se quedan igual ...

        [Header("Configuración de Victoria")]
        // Aquí arrastraremos tu nuevo texto bonito de "¡Correcto!" o "Has completado este Nivel"
        [SerializeField] private GameObject textoVictoria;

        // Esta función la llamaremos cuando el jugador toque el objeto vacío (meta)
        public void TerminarNivelYIrAlMapa()
        {
            if (textoVictoria != null)
            {
                textoVictoria.SetActive(true); // Enciende tu texto en la posición nueva
            }

            // Carga la escena del mapa. Cambia "Mapa" por el nombre exacto de tu escena si se llama distinto.
            Time.timeScale = 1f;
            SceneManager.LoadScene("Mapa");
        }
    }
}
