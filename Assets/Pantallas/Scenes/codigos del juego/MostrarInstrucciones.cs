
using UnityEngine;

public class MostrarInstrucciones : MonoBehaviour
{
    public GameObject imagenInstrucciones;

    void Start()
    {
        // Mostrar las instrucciones al entrar al nivel
        imagenInstrucciones.SetActive(true);
    }

    void Update()
    {
        // Ocultar las instrucciones al presionar Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            imagenInstrucciones.SetActive(false);
        }
    }
}