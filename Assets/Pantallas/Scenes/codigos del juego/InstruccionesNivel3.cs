using UnityEngine;

public class InstruccionesNivel3 : MonoBehaviour
{
    public GameObject panelInstrucciones;

    private static bool instruccionesYaMostradas = false;

    void Start()
    {
        if (!instruccionesYaMostradas)
        {
            // Mostrar instrucciones solamente la primera vez
            panelInstrucciones.SetActive(true);

            // Recordar que ya fueron mostradas
            instruccionesYaMostradas = true;
        }
        else
        {
            // Si el jugador perdió y el nivel se reinició,
            // no volver a mostrar las instrucciones
            panelInstrucciones.SetActive(false);
        }
    }

    void Update()
    {
        // ENTER oculta las instrucciones
        if (panelInstrucciones.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            panelInstrucciones.SetActive(false);
        }
    }
}