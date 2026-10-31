using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public Transform PuntoC;
    public Transform PuntoD;
    public bool izquierda;
    public float velocidad = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 posiciondeseada = Vector3.zero;
        if (izquierda)

            posiciondeseada = PuntoC.position;
        else
            posiciondeseada = PuntoD.position;



        Vector3 direccion = (posiciondeseada - transform.position);
        transform.position += direccion.normalized * Time.deltaTime * velocidad;
        if (direccion.magnitude < 0.03f)
        {
            if (izquierda)
                izquierda = false;

            else
                izquierda = true;

        }
    }
}
