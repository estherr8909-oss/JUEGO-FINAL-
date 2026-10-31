using UnityEngine;

public class ActivarRetroalimentacion : MonoBehaviour
{
    public GameObject retroalimentacion;

    private void Start()
    {
        retroalimentacion.SetActive(false);
    }

    private void OnDestroy()
    {
        if (retroalimentacion != null)
        {
            retroalimentacion.SetActive(true);
        }
    }

    private void Update()
    {
        if (retroalimentacion.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            retroalimentacion.SetActive(false);
        }
    }
}