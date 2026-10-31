using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Nivel3Esther
{
    public class piedra2 : MonoBehaviour
    {
        [System.Serializable]
        public class PreguntaData
        {
            public string pregunta;
            public string respuestaCorrecta;
            public string respuestaIncorrecta1;
            public string respuestaIncorrecta2;
        }

        [Header("Referencias de UI")]
        public GameObject panelPregunta;
        public GameObject estrellaPiedra2;
        public TMP_Text textoPregunta;
        public TMP_Text textoOpcionA;
        public TMP_Text textoOpcionB;
        public TMP_Text textoOpcionC;
        public TMP_Text mensaje;

        private PreguntaData[] ejercicios = new PreguntaData[]
    {
        new PreguntaData { pregunta = "14 x 2 = ?", respuestaCorrecta = "28", respuestaIncorrecta1 = "24", respuestaIncorrecta2 = "26" },
        new PreguntaData { pregunta = "14 x 4 = ?", respuestaCorrecta = "56", respuestaIncorrecta1 = "48", respuestaIncorrecta2 = "52" },
        new PreguntaData { pregunta = "14 x 6 = ?", respuestaCorrecta = "84", respuestaIncorrecta1 = "78", respuestaIncorrecta2 = "82" }
    };

       
        private IEnumerator EsperarYOcultarPanel()
        {
            yield return new WaitForSecondsRealtime(1.5f);

            if (ControlPreguntas.Instance != null)
            {
                foreach (var estrella in FindObjectsByType<BrilloEstrella>(FindObjectsInactive.Exclude, FindObjectsSortMode.None))
                {
                    estrella.Iluminar(1.0f);
                }
                ControlPreguntas.Instance.GanarEstrella(1, 200);
            }
            else
            {
                ControlPreguntas controladorAlternativo = FindAnyObjectByType<ControlPreguntas>();
                if (controladorAlternativo != null)
                {
                    controladorAlternativo.GanarEstrella(1, 200);
                }
            }

            if (panelPregunta != null)
            {
                panelPregunta.SetActive(false);
            }

            Time.timeScale = 1f;
            Destroy(gameObject);
        }
        private int indiceEjerciciosActual = 0;
        private string respuestaCorrectaActual = "";
        private bool preguntaActiva = false;

        private void Start()
        {
            LimpiarMensaje();
            if (panelPregunta != null) panelPregunta.SetActive(false);
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
            if (indiceEjerciciosActual >= ejercicios.Length) return;

            PreguntaData actual = ejercicios[indiceEjerciciosActual];

            if (textoPregunta != null) textoPregunta.text = actual.pregunta;

            respuestaCorrectaActual = actual.respuestaCorrecta.Trim();

            List<string> listaOpciones = new List<string>
            {
                actual.respuestaCorrecta.Trim(),
                actual.respuestaIncorrecta1.Trim(),
                actual.respuestaIncorrecta2.Trim()
            };

            // Mezclamos al azar las opciones en los botones
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


        public void ValidarRespuesta(TMP_Text textoBotonPresionado)
        {
            string textoSeleccionado = textoBotonPresionado.text.Trim().Replace("\u200B", "").Replace("\uFEFF", "");
            string respuestaCorrectaLimpia = respuestaCorrectaActual.Trim().Replace("\u200B", "").Replace("\uFEFF", "");

            if (textoSeleccionado == respuestaCorrectaLimpia)
            {
                indiceEjerciciosActual++;
                LimpiarMensaje();

                
                if (indiceEjerciciosActual >= ejercicios.Length)
                {
                    ControlPreguntas.Instance?.GanarEstrella(1, 200);
                    if (estrellaPiedra2 != null)
                    {
                        FindAnyObjectByType<ControladorVictoria>()?.IluminarEstrella(2);
                    }
                    // 2. Ocultamos el panel de preguntas y destruimos el collider/objeto de la piedra
                    if (panelPregunta != null)
                    {
                        panelPregunta.SetActive(false);
                    }

                    Time.timeScale = 1f;
                    Destroy(gameObject);
                }
                else
                {
                    // Si aún quedan preguntas, carga la siguiente
                    CargarEjercicioActual();
                }
            }
            else
            {
                Debug.Log("Respuesta incorrecta detectada");
                if (mensaje != null)
                {
                    mensaje.gameObject.SetActive(true);
                    mensaje.text = "¡Casi! Recuerda que multiplicar es sumar el mismo número.";
                    mensaje.color = Color.white;
                }
            }
        }


        public void LimpiarMensaje()
        {
            if (mensaje != null) mensaje.text = "";
        }
    }
}
