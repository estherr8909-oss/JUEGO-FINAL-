
using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject imagenInstrucciones;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            imagenInstrucciones.SetActive(false);
        }
    }
}
