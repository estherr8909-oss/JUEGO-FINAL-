
using UnityEngine;

public class EstrellaRecolectable : MonoBehaviour
{
    [SerializeField] private EstadisticasNivel estadisticas;

    private bool recogida;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (recogida || !other.CompareTag("Player"))
            return;

        recogida = true;
        estadisticas.RecogerEstrella();

        Destroy(gameObject);
    }
}