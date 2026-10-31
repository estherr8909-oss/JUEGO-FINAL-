using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntosNiveles : MonoBehaviour
{
    public string nombreDeLaEscena;
    private bool jugadorEstaEncima = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorEstaEncima && Input.GetKeyDown(KeyCode.Return))
        {
            EntrarAlNivel();
        }
    }

    private void EntrarAlNivel()
    {
        Debug.Log("Cargando: " + nombreDeLaEscena); // carga la escena que correponde
        SceneManager.LoadScene(nombreDeLaEscena);
    }

    private void OnTriggerEnter2D(Collider2D collision) // verificar si lo que toco el punto es el jugador 
    {
        if (collision.CompareTag("player"))
        {
            jugadorEstaEncima = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // esto es si el jugador se aleja del punto 
    {
        if (collision.CompareTag("player"))
        {
            jugadorEstaEncima = false;
        }
    }
}
