using UnityEngine;

namespace Nivel3Esther
{
    public class Transicion : MonoBehaviour
    {
        public GameObject panelActual;
        public GameObject panelSiguiente;

        public void SiguienteNivel()
        {
            if (panelActual != null) panelActual.SetActive(false);
            if (panelSiguiente != null) panelSiguiente.SetActive(true);
        }
    }
}
