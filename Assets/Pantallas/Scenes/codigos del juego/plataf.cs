using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlataformaRespuesta : MonoBehaviour
   
{

    private Puerta puerta;

    private bool tiene2 = false;
    private bool tiene4 = false;

    public Puerta Puerta { get => puerta; set => puerta = value; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CuboNumero cubo = other.GetComponent<CuboNumero>();

        if (cubo != null)
        {
            if (cubo.numero == "2")
                tiene2 = true;

            if (cubo.numero == "4")
                tiene4 = true;

            if (tiene2 && tiene4)
            {
                Debug.Log("Respuesta correcta");
                
                Debug.Log("la puerta esta activada");
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CuboNumero cubo = other.GetComponent<CuboNumero>();

        if (cubo != null)
        {
            if (cubo.numero == "2")
                tiene2 = false;

            if (cubo.numero == "4")
                tiene4 = false;
        }
    }
}

