
using UnityEngine;
using TMPro;

public class PantallaNivelCompletado : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [Header("Textos TextMeshPro")]
    [SerializeField] private TMP_Text puntosTMP;
    [SerializeField] private TMP_Text estrellasTMP;
    [SerializeField] private TMP_Text porcentajeTMP;

    private bool mostrado = false;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void MostrarPantalla(
        int puntos,
        int estrellas,
        int objetivosCompletados,
        int objetivosTotales)
    {
        if (mostrado)
            return;

        mostrado = true;

        int porcentaje = objetivosTotales > 0
            ? Mathf.RoundToInt(
                Mathf.Clamp01(
                    (float)objetivosCompletados / objetivosTotales
                ) * 100f)
            : 0;

        puntosTMP.text = puntos.ToString();
        estrellasTMP.text = estrellas.ToString();
        porcentajeTMP.text = porcentaje.ToString();

        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}
