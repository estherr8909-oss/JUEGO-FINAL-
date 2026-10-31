using UnityEngine;

/// <summary>
/// Hace que el objeto parpadee entre dos colores continuamente
/// </summary>
public class ParpadeoColor : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 5f; // Velocidad del parpadeo

    private SpriteRenderer sprite;

    /// <summary>
    /// Se ejecuta una sola vez al iniciar el juego
    /// </summary>
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Se ejecuta cada frame y cambia los colores
    /// </summary>
    void Update()
    {
        if (Mathf.FloorToInt(Time.time * velocidad) % 2 == 0)
            sprite.color = Color.green;
        else
            sprite.color = Color.blue;
    }
}