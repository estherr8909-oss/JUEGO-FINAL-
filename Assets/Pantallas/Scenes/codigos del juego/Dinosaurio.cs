using UnityEngine;

public class Dinosaurio : MonoBehaviour
{
    public Transform PuntoE;
    public Transform PuntoF;
    public bool derecha;
    public float velocidad = 3;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posiciondeseada = Vector3.zero;
        if (derecha)
        {
            posiciondeseada = PuntoE.position;
            spriteRenderer.flipX = true;
        }
        else
        {
            posiciondeseada = PuntoF.position;
            spriteRenderer.flipX = false;
        }
            



        Vector3 direccion = (posiciondeseada - transform.position);
        transform.position += direccion.normalized * Time.deltaTime * velocidad;
        if (direccion.magnitude < 0.03f)
        {
            if (derecha)
                derecha = false;
            else
                derecha = true;

        }
    }
}
