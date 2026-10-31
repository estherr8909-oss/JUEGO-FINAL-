using UnityEngine;

public class stars : MonoBehaviour
{
    public float puntos = 10f;
    public Puntaje puntaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}