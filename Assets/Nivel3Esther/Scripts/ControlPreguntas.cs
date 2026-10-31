using UnityEngine;
using TMPro;

namespace Nivel3Esther
{
    public class ControlPreguntas : MonoBehaviour
    {
        public static ControlPreguntas Instance;
        public TMP_Text textoEstrellas;
        public GameObject[] imagenesEstrellas;
        public TMP_Text textoPuntos;
        public int estrellas = 0;
        public int puntos = 0;
        private readonly bool[] piedrasCompletadas = new bool[3];

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            Time.timeScale = 1f;
        }

        private void Start()
        {
            // Preserve the existing stars in the imported scene instead of hiding
            // the objects on which BrilloEstrella starts its animation.
            if (textoPuntos != null) textoPuntos.gameObject.SetActive(true);
            ActualizarUI();
        }

        public void GanarEstrella(int indicePiedra, int puntosOtorgados)
        {
            if (indicePiedra < 0 || indicePiedra >= piedrasCompletadas.Length ||
                piedrasCompletadas[indicePiedra]) return;
            piedrasCompletadas[indicePiedra] = true;
            estrellas++;
            puntos += Mathf.Max(0, puntosOtorgados);
            if (imagenesEstrellas != null && indicePiedra < imagenesEstrellas.Length &&
                imagenesEstrellas[indicePiedra] != null)
            {
                imagenesEstrellas[indicePiedra].SetActive(true);
            }
            ActualizarUI();
        }

        public void ActualizarUI()
        {
            if (textoEstrellas != null) textoEstrellas.text = estrellas.ToString();
            if (textoPuntos != null) textoPuntos.text = "Puntos: " + puntos;
        }

        private void OnDestroy()
        {
            if (Instance == this) Instance = null;
        }
    }
}
