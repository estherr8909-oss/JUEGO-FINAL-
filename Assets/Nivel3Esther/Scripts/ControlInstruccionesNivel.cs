using UnityEngine;

namespace Nivel3Esther
{
    public class ControlInstruccionesNivel : MonoBehaviour
    {
        public GameObject panelInstrucciones;

        void Start()
        {
            // Al iniciar, solo mostramos el panel sin congelar el tiempo
            if (panelInstrucciones != null)
            {
                panelInstrucciones.SetActive(true);
            }
        }

        void Update()
        {
            // Si presionas espacio, cerramos el panel para que el juego siga normal
            if (panelInstrucciones != null && panelInstrucciones.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    panelInstrucciones.SetActive(false);
                }
            }
        }
    }
}
