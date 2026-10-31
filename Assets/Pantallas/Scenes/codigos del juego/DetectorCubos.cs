
using UnityEngine;
using System.Collections.Generic;

public class DetectorCubos : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private PantallaNivelCompletado pantallaVictoria;
    [SerializeField] private EstadisticasNivel estadisticas;

    private readonly HashSet<CuboNumero> cubosDentro =
        new HashSet<CuboNumero>();

    private bool nivelCompletado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CuboNumero cubo = other.GetComponentInParent<CuboNumero>();

        if (cubo != null)
        {
            cubosDentro.Add(cubo);
            ComprobarCubos();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CuboNumero cubo = other.GetComponentInParent<CuboNumero>();

        if (cubo != null)
        {
            cubosDentro.Remove(cubo);
        }
    }

    private void ComprobarCubos()
    {
        if (nivelCompletado)
            return;

        bool tieneDos = false;
        bool tieneCuatro = false;

        foreach (CuboNumero cubo in cubosDentro)
        {
            if (cubo == null)
                continue;

            if (cubo.numero == "2")
                tieneDos = true;

            if (cubo.numero == "4")
                tieneCuatro = true;
        }

        if (tieneDos && tieneCuatro)
        {
            if (pantallaVictoria == null || estadisticas == null)
            {
                Debug.LogError(
                    "Asigna Pantalla Victoria y Estadisticas " +
                    "en el Inspector de DetectorCubos."
                );
                return;
            }

            nivelCompletado = true;

            estadisticas.CompletarObjetivo();

            pantallaVictoria.MostrarPantalla(
                estadisticas.Puntos,
                estadisticas.Estrellas,
                estadisticas.ObjetivosCompletados,
                estadisticas.ObjetivosTotales
            );
        }
    }
}