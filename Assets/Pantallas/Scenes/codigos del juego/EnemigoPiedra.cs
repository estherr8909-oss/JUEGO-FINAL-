using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemigoPiedra : MonoBehaviour
{
    public Transform PuntoA;
    public Transform PuntoB;
    public bool arriba;
    public float velocidad =3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posiciondeseada = Vector3.zero;
        if (arriba) 
        
            posiciondeseada = PuntoA.position;
        else
            posiciondeseada = PuntoB.position;

        

        Vector3 direccion = (posiciondeseada - transform.position);
        transform.position += direccion.normalized * Time.deltaTime * velocidad;
        if (direccion.magnitude < 0.02f)
        {
           if (arriba)
            arriba = false;

            else 
                arriba = true;

        }

    
}
}
