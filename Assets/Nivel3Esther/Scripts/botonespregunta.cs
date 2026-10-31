using UnityEngine;

namespace Nivel3Esther
{
    public class botonespregunta : MonoBehaviour
    {
        [Header("Objetos de la Escena")]
        public GameObject Piedra1;
        public GameObject panel1;

        // Conecta esta función en On Click() del botón CORRECTO
        public void RespuestaCorrecta()
        {
            Debug.Log("¡Respuesta Correcta!");

            // Desactiva la piedra y el panel actual al acertar
            if (Piedra1 != null) Piedra1.SetActive(false);
            if (panel1 != null) panel1.SetActive(false);
        }

        // Conecta esta función en On Click() de los botones INCORRECTOS
        public void RespuestaIncorrecta()
        {
            Debug.Log("Respuesta Incorrecta");
            // No hace nada para que la pantalla se quede exactamente igual
        }
    }
}
