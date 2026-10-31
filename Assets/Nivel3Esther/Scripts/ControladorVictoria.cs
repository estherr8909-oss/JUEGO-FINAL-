using UnityEngine;

public class ControladorVictoria : MonoBehaviour
{
    [Header("Referencias de las Estrellas")]
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

  

    // Función pública para activar el parpadeo de todas las estrellas al mismo tiempo
    public void HacerParpadearTodas()
    {
        if (estrella1 != null)
        {
            BrilloEstrella brillo1 = estrella1.GetComponent<BrilloEstrella>();
            if (brillo1 != null) brillo1.Iluminar(0.5f);
        }

        if (estrella2 != null)
        {
            BrilloEstrella brillo2 = estrella2.GetComponent<BrilloEstrella>();
            if (brillo2 != null) brillo2.Iluminar(0.5f);
        }

        if (estrella3 != null)
        {
            BrilloEstrella brillo3 = estrella3.GetComponent<BrilloEstrella>();
            if (brillo3 != null) brillo3.Iluminar(0.5f);
        }
    }

    // Función para iluminar únicamente la estrella que corresponda (1, 2 o 3)
    public void IluminarEstrella(int numeroEstrella)
    {
        if (numeroEstrella == 1 && estrella1 != null)
        {
            BrilloEstrella brillo1 = estrella1.GetComponent<BrilloEstrella>();
            if (brillo1 != null) brillo1.Iluminar(0.5f);
        }
        else if (numeroEstrella == 2 && estrella2 != null)
        {
            BrilloEstrella brillo2 = estrella2.GetComponent<BrilloEstrella>();
            if (brillo2 != null) brillo2.Iluminar(0.5f);
        }
        else if (numeroEstrella == 3 && estrella3 != null)
        {
            BrilloEstrella brillo3 = estrella3.GetComponent<BrilloEstrella>();
            if (brillo3 != null) brillo3.Iluminar(0.5f);
        }
    }
}