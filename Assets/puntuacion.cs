using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float cantidadPuntos)
    {
        puntos += cantidadPuntos;
        textMesh.text = puntos.ToString("0");
    }
}