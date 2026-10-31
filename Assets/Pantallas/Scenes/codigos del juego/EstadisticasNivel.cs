
using UnityEngine;

public class EstadisticasNivel : MonoBehaviour
{
    [Header("Estadísticas")]
    [SerializeField] private int puntos;
    [SerializeField] private int estrellas;
    [SerializeField] private int estrellasTotales = 7;

    [Header("Objetivos")]
    [SerializeField] private int objetivosCompletados;
    [SerializeField] private int objetivosTotales = 1;

    public int Puntos => puntos;
    public int Estrellas => estrellas;
    public int EstrellasTotales => estrellasTotales;

    public int ObjetivosCompletados => objetivosCompletados;
    public int ObjetivosTotales => objetivosTotales;

    public int Porcentaje
    {
        get
        {
            if (objetivosTotales <= 0)
                return 0;

            return Mathf.RoundToInt(
                Mathf.Clamp01(
                    (float)objetivosCompletados / objetivosTotales
                ) * 100f
            );
        }
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += Mathf.Max(0, cantidad);
    }

    public void RecogerEstrella()
    {
        if (estrellas < estrellasTotales)
            estrellas++;
    }

    public void CompletarObjetivo()
    {
        objetivosCompletados =
            Mathf.Min(objetivosCompletados + 1, objetivosTotales);
    }
}