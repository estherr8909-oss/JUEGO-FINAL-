using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int estrellasRecolectadas = 0;

    [Header("UI Elementos")]
    public GameObject panelEjercicio; // El panel que ocultamos 
    public TMP_InputField campoRespuesta; // El cuadro de texto para escribir 
    public TextMeshProUGUI textoPregunta;
    private MovimientoJugador jugador;

    private void Start()
    {
        jugador = FindAnyObjectByType<MovimientoJugador>();
    }

    [Header("Ejercicios")]
    string[] preguntas =
    {
        "12 x 2 = ?",
        "10 x 3 = ?",
        "11 x 4 = ?",
        "7  x 8 = ?",
        "9 x 7 = ?"
    };

    string [] respuestas =
    {
        "24",
        "30",
        "44",
        "56",
        "63"
    }; 

    int ejercicioActual = 0; 
    


    private bool juegoPausadoPorEjercicio = false;

    public void RecolectarEstrella()
    {
        estrellasRecolectadas++;

        if (estrellasRecolectadas >= 5 )
        {
            ActivarEjercicio();
        }
    }

    void ActivarEjercicio()
    {
        juegoPausadoPorEjercicio = true;
        panelEjercicio.SetActive(true); //Hace visible el panel
        campoRespuesta.ActivateInputField(); //Pone el curso listo para escribir 
    }

    public void VerificarRespuesta()
    {
        if (campoRespuesta.text == respuestas[ejercicioActual])
        {
            textoPregunta.text = "¡Muy bien ! Eres bueno con las matemáticas.";
            jugador.SumarPuntos(5);
            StartCoroutine(EsperarSiguienteEjercicio());
            
        }
        else
        {
            textoPregunta.text = "¡No te rindas! Revisa tu respuesta y vuelve a intentarlo.";
            jugador.RestarPunto(5);
            campoRespuesta.text = "";
            StartCoroutine(EsperarMostratrEjercicio());
            campoRespuesta.ActivateInputField();
        }
    }


    // ESPERAR Y CAMBIAR EJERCICIO
    IEnumerator EsperarSiguienteEjercicio()
    {
        yield return new WaitForSeconds(3f);

        if (ejercicioActual < preguntas.Length - 1)
        {
            ejercicioActual++;

            textoPregunta.text = preguntas[ejercicioActual];

            campoRespuesta.text = "";
            campoRespuesta.ActivateInputField();
        }
        else
        {
            textoPregunta.text = "¡Completaste los 4 ejercicios!";

            ContinuarJuego();
        }            
    }

    IEnumerator EsperarMostratrEjercicio()
    {
        yield return new WaitForSeconds(3f);
        textoPregunta.text = preguntas[ejercicioActual];
        campoRespuesta.ActivateInputField();
    }

        void ContinuarJuego ()
    {
        panelEjercicio.SetActive(false); // ocultar de nuevo el panel
        Time.timeScale = 1f;             // reanuda el tiempo del juego 
        juegoPausadoPorEjercicio = false;

        SceneManager.LoadScene("Mapa");
    }

     
    void Update()
    {
        
    }
}
