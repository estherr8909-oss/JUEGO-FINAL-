using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Nivel3Esther
{
    public class Piedra : MonoBehaviour
    {
        [Header("Referencias de UI")]
        public GameObject panelPregunta;
        public TMP_Text textoPregunta;
        public TMP_Text textoOpcionA;
        public TMP_Text textoOpcionB;
        public TMP_Text textoOpcionC;
        public TMP_Text mensaje;
        [Header("Panel Explicativo de la Primera Piedra")]
        public GameObject panelExplicacion;
        private static bool primeraPiedraEliminada = false;

        [SerializeField] public GameObject estrellaPiedra;
        [System.Serializable]
        public struct PreguntaData
        {
            public string pregunta;
            public string respuestaCorrecta;
            public string respuestaIncorrecta1;
            public string respuestaIncorrecta2;
        }

        public PreguntaData[] ejercicios = new PreguntaData[]
        {
            new PreguntaData { pregunta = "10 x 5 = ?", respuestaCorrecta = "50", respuestaIncorrecta1 = "35", respuestaIncorrecta2 = "48" },
            new PreguntaData { pregunta = "10 x 3 = ?", respuestaCorrecta = "30", respuestaIncorrecta1 = "20", respuestaIncorrecta2 = "48" },
            new PreguntaData { pregunta = "10 x 8 = ?", respuestaCorrecta = "80", respuestaIncorrecta1 = "85", respuestaIncorrecta2 = "70" }
        };

        private int indiceEjercicioActual = 0;
        private string respuestaCorrectaActual = "";
        private bool preguntaActiva = false;

        private void Awake()
        {
            primeraPiedraEliminada = false;
        }
        private void Start()
        {
            LimpiarMensaje();
            if (panelPregunta != null) panelPregunta.SetActive(false);
        }
        void Update()
        {
            if (panelExplicacion != null && panelExplicacion.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    panelExplicacion.SetActive(false);
                    Time.timeScale = 1f; // Reanuda el juego
                }

                if (estrellaPiedra != null)
                {
                    BrilloEstrella brillo = estrellaPiedra.GetComponent<BrilloEstrella>();
                    if (brillo != null)
                    {
                        brillo.Iluminar(0.5f);
                    }
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !preguntaActiva)
            {
                preguntaActiva = true;
                if (panelPregunta != null) panelPregunta.SetActive(true);

                LimpiarMensaje();
                CargarEjercicioActual();
                Time.timeScale = 0f;
            }
        }

        public void CargarEjercicioActual()
        {
            if (indiceEjercicioActual >= ejercicios.Length) return;

            PreguntaData actual = ejercicios[indiceEjercicioActual];

            if (textoPregunta != null) textoPregunta.text = actual.pregunta;

            respuestaCorrectaActual = actual.respuestaCorrecta.Trim();

            List<string> listaOpciones = new List<string>
            {
                actual.respuestaCorrecta.Trim(),
                actual.respuestaIncorrecta1.Trim(),
                actual.respuestaIncorrecta2.Trim()
            };

            // Mezclamos al azar
            for (int i = 0; i < listaOpciones.Count; i++)
            {
                string temp = listaOpciones[i];
                int aleatorio = Random.Range(i, listaOpciones.Count);
                listaOpciones[i] = listaOpciones[aleatorio];
                listaOpciones[aleatorio] = temp;
            }

            if (textoOpcionA != null) textoOpcionA.text = listaOpciones[0];
            if (textoOpcionB != null) textoOpcionB.text = listaOpciones[1];
            if (textoOpcionC != null) textoOpcionC.text = listaOpciones[2];
        }

        public void SeleccionarOpcionA() { ValidarRespuesta(textoOpcionA); }
        public void SeleccionarOpcionB() { ValidarRespuesta(textoOpcionB); }
        public void SeleccionarOpcionC() { ValidarRespuesta(textoOpcionC); }

        private void ValidarRespuesta(TMP_Text textoBotonPresionado)
        {
            if (indiceEjercicioActual >= ejercicios.Length || textoBotonPresionado == null) return;

            string textoSeleccionado = textoBotonPresionado.text.Trim().Replace("\u200B", "").Replace("\u00A0", "");
            string respuestaCorrectaLimpia = respuestaCorrectaActual.Trim().Replace("\u200B", "").Replace("\u00A0", "");

            if (textoSeleccionado == respuestaCorrectaLimpia)
            {
                indiceEjercicioActual++;
                LimpiarMensaje();
                FindAnyObjectByType<ControladorVictoria>()?.IluminarEstrella(1);

                if (indiceEjercicioActual < ejercicios.Length)
                {
                    CargarEjercicioActual();
                }
                else
                {
                    if (panelPregunta != null)
                    {
                        panelPregunta.SetActive(false);
                    }
                    ControlPreguntas.Instance?.GanarEstrella(0, 100);
                    Time.timeScale = 1f;
                    if (!primeraPiedraEliminada && panelExplicacion != null)
                    {
                        primeraPiedraEliminada = true;
                        panelExplicacion.SetActive(true); // Muestra el panel explicativo
                        Time.timeScale = 0f;              // Pausa el juego para que el niño lo lea
                    }

                  Destroy(gameObject);
                }

            }
            else
            {
                if (mensaje != null)
                {
                    mensaje.text = "¡Incorrecto ¡Prueba de nuevo.";
                }
            }
        }
        public void CerrarPanelYContinuar()
        {
            if (panelExplicacion != null)
            {
                panelExplicacion.SetActive(false);
            }
            Time.timeScale = 1f;
        }

        
        public void LimpiarMensaje()
        {
            if (mensaje != null) mensaje.text = "";
        }
    }
}
