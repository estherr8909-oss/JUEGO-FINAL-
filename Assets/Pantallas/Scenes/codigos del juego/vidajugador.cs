
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VidaJugador : MonoBehaviour
{
    public int vidas = 3;
    public Image[] corazones;

    public float tiempoInvulnerabilidad = 2f;

    public GameOverManager gameOverManager;

    private bool invulnerable = false;
    private bool muerto = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pincho") &&
            !invulnerable && !muerto)
        {
            PerderVida();
        }
    }

    void PerderVida()
    {
        vidas--;

        // Quitar un corazon
        if (vidas >= 0 && vidas < corazones.Length)
        {
            corazones[vidas].gameObject.SetActive(false);
        }

        // Si pierde todas las vidas
        if (vidas <= 0)
        {
            muerto = true;
            invulnerable = false;

            // Mostrar el panel Game Over
            if (gameOverManager != null)
            {
                gameOverManager.MostrarGameOver();
            }
            else
            {
                Debug.LogError(
                    "Asigna el GameOverManager en el Inspector"
                );
            }

            return;
        }

        StartCoroutine(Invulnerabilidad());
    }

    IEnumerator Invulnerabilidad()
    {
        invulnerable = true;

        yield return new WaitForSeconds(
            tiempoInvulnerabilidad
        );

        invulnerable = false;
    }
}