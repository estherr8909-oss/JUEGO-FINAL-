using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

namespace Nivel3Esther
{
    public class Piedra3 : MonoBehaviour
    {
        [Header("Configuración de Referencias")]
        [SerializeField] private GameObject panelPregunta;
        [SerializeField] private TMP_Text TextoMensaje3;
        [SerializeField] private TMP_Text textoOpcionA;
        [SerializeField] private TMP_Text textoOpcionB;
        [SerializeField] private TMP_Text textoOpcionC;
        [SerializeField] private TMP_Text mensaje;
        [SerializeField] public GameObject estrellaPiedra3;
        [System.Serializable]
        public struct PreguntaData
        {
            public string pregunta;
            public string respuestaCorrecta;
            public string respuestaIncorrecta1;
            public string respuestaIncorrecta2;
        }

        private PreguntaData[] ejercicios = new PreguntaData[]
        {
            new PreguntaData { pregunta = "17 x 5 = ?", respuestaCorrecta = "85", respuestaIncorrecta1 = "89", respuestaIncorrecta2 = "49" },
            new PreguntaData { pregunta = "17 x 7 = ?", respuestaCorrecta = "119", respuestaIncorrecta1 = "109", respuestaIncorrecta2 = "124" },
            new PreguntaData { pregunta = "17 x 4 = ?", respuestaCorrecta = "68", respuestaIncorrecta1 = "62", respuestaIncorrecta2 = "74" }
        };

        private int indiceEjercicioActual = 0;
        private string respuestaCorrectaActual = "";
        private bool preguntaActiva = false;
        private MonoBehaviour movimientoJugador;

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

                movimientoJugador = other.GetComponent<MovimientoJugador>();
                if (movimientoJugador != null) movimientoJugador.enabled = false;

                LimpiarMensaje();
                CargarEjercicioActual();
                Time.timeScale = 0f;
            }
        }

        public void CargarEjercicioActual()
        {
            if (indiceEjercicioActual >= ejercicios.Length) return;

            PreguntaData actual = ejercicios[indiceEjercicioActual];

            if (TextoMensaje3 != null) TextoMensaje3.text = actual.pregunta;

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

        private void ValidarRespuesta(TMP_Text textoBotonPresionado)
        {
            if (indiceEjercicioActual >= ejercicios.Length || textoBotonPresionado == null) return;

            string textoSeleccionado = textoBotonPresionado.text.Trim().Replace("\u200B", "").Replace("\u00A0", "").Replace(" ", "");
            string respuestaCorrectaLimpia = respuestaCorrectaActual.Trim().Replace("\u200B", "").Replace("\u00A0", "").Replace(" ", "");

            if (textoSeleccionado == respuestaCorrectaLimpia)
            {
                indiceEjercicioActual++;
                LimpiarMensaje();

                if (indiceEjercicioActual < ejercicios.Length)
                {
                    CargarEjercicioActual();
                }
                else
                {
                    RespuestaCorrecta();
                }
            }
            else
            {
                RespuestaIncorrecta();
            }
        }

        private void RespuestaIncorrecta()
        {
            if (mensaje != null)
            {
                mensaje.text = "¡Vas por buen camino ¡tú puedes!";
            }
        }

        private void RespuestaCorrecta()
        {
            if (estrellaPiedra3 != null)
            {
                BrilloEstrella brillo = estrellaPiedra3.GetComponent<BrilloEstrella>();
                if (brillo != null)
                {
                    brillo.Iluminar(0.5f);
                }
            }
            if (mensaje != null)
            {
                mensaje.text = "¡Increíble! ¡Lo lograste con muchísimo éxito! ¡Eres genial!";
            }

            if (movimientoJugador != null)
            {
                movimientoJugador.enabled = true;
            }
            if (estrellaPiedra3 != null)
            {
                FindAnyObjectByType<ControladorVictoria>()?.HacerParpadearTodas();
            }
            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
            {
                col.enabled = false;
            }

            // Usamos una corrutina para que la pausa del juego no congele la espera
            StartCoroutine(EsperarYOcultarPanel());
        }

        private IEnumerator EsperarYOcultarPanel()
        {
            yield return new WaitForSecondsRealtime(1.5f);

            if (panelPregunta != null) panelPregunta.SetActive(false);
            if (ControlPreguntas.Instance != null)
            {
                ControlPreguntas.Instance.GanarEstrella(2, 300); // 1 estrella + 300 puntos
            }
            else
            {
                ControlPreguntas controladorAlternativo = FindAnyObjectByType<ControlPreguntas>();
                if (controladorAlternativo != null)
                {
                    controladorAlternativo.GanarEstrella(2, 300);
                }
            }
            Time.timeScale = 1f;
            Destroy(gameObject);
        }

        public void LimpiarMensaje()
        {
            if (mensaje != null) mensaje.text = "";
        }
    }
}
