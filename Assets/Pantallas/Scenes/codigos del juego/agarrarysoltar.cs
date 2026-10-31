using UnityEngine;

public class AgarrarNumero : MonoBehaviour
{
    public Transform puntoCarga;

    private GameObject objetoCerca;
    private GameObject objetoAgarrado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (objetoAgarrado == null)
            {
                Agarrar();
            }
            else
            {
                Soltar();
            }
        }
    }

    void Agarrar()
    {
        if (objetoCerca != null)
        {
            objetoAgarrado = objetoCerca;

            Rigidbody2D rb = objetoAgarrado.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = false;
            }

            objetoAgarrado.transform.SetParent(puntoCarga);
            objetoAgarrado.transform.localPosition = Vector3.zero;
        }
    }

    void Soltar()
    {
        objetoAgarrado.transform.SetParent(null);

        Rigidbody2D rb = objetoAgarrado.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }

        objetoAgarrado = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Numero"))
        {
            objetoCerca = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Numero"))
        {
            objetoCerca = null;
        }
    }
}