using UnityEngine;

namespace Nivel3Esther
{
    public class CerrarPanelExplicacion : MonoBehaviour
    {
        public GameObject panelExplicacion;

        public void Cerrar()
        {
            if (panelExplicacion != null) panelExplicacion.SetActive(false);
            Time.timeScale = 1f;
        }

        private void Update()
        {
            if (panelExplicacion != null && panelExplicacion.activeSelf &&
                Input.GetKeyDown(KeyCode.Space)) Cerrar();
        }
    }
}
