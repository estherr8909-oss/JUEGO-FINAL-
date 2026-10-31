using UnityEngine;
using UnityEngine.UI;

public class ControladorEstrellas : MonoBehaviour
{
    public Image[] estrellas;

    private int estrellasConseguidas = 0;

    void Start()
    {
        // Todas empiezan apagadas
        for (int i = 0; i < estrellas.Length; i++)
        {
            estrellas[i].color = new Color(0.4f, 0.4f, 0.4f, 1f);
        }
    }

    public void ActivarEstrella()
    {
        if (estrellasConseguidas < estrellas.Length)
        {
            estrellas[estrellasConseguidas].color = Color.yellow;

            estrellasConseguidas++;
        }
    }
}