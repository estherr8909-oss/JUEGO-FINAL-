using UnityEngine;

public class mpausa : MonoBehaviour
{
    [SerializeField] private GameObject botonpusa;
    [SerializeField] private GameObject Menupausa;


    public void Pausa()
    {
        Time.timeScale = 0f;
        Menupausa.SetActive(true);;
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        
        Menupausa.SetActive(false);
    }
       
    
}