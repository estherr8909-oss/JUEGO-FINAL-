using UnityEngine;
using UnityEngine.SceneManagement; // Obligatorio para cambiar de escena

namespace Nivel3Esther
{
    public class PortalMeta : MonoBehaviour
    {
        // Al tocar el objeto vacío, cargará el mapa de inmediato
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // "Mapa" debe ser el nombre exacto de tu escena
            if (!collision.CompareTag("Player")) return;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Mapa");
        }
    }
}
