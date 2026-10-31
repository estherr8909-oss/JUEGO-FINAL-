using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrilloEstrella : MonoBehaviour
{
    private Image imagenEstrella;
    private bool estaParpadeando = false;

    void Start()
    {
        imagenEstrella = GetComponent<Image>();
        if (imagenEstrella != null)
        {
            Color c = imagenEstrella.color;
            c.a = 1f;
            imagenEstrella.color = c;
        }
    }

    // Ahora acepta el parámetro de tiempo (0.5f) que le envía el ControladorVictoria
    public void Iluminar(float tiempo =0.5f)
    {
        if (!estaParpadeando)
        {
            StartCoroutine(RutinaParpadeo(tiempo));
        }
    }

    IEnumerator RutinaParpadeo(float tiempo)
    {
        estaParpadeando = true;
        for (int i = 0; i < 3; i++)
        {
            if (imagenEstrella != null)
            {
                Color c = imagenEstrella.color;
                c.a = 0.3f;
                imagenEstrella.color = c;
            }
            yield return new WaitForSeconds(tiempo);

            if (imagenEstrella != null)
            {
                Color c = imagenEstrella.color;
                c.a = 1.0f;
                imagenEstrella.color = c;
            }
            yield return new WaitForSeconds(tiempo);
        }
        estaParpadeando = false;
    }
}