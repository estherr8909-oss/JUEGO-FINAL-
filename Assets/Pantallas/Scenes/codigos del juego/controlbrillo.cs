using UnityEngine;
using UnityEngine.UI;

public class ControlBrillo : MonoBehaviour
{
    public Slider sliderBrillo;
    public Image panelBrillo;

    void Start()
    {
        sliderBrillo.minValue = 0f;
        sliderBrillo.maxValue = 1f;
        sliderBrillo.value = 1f;

        sliderBrillo.onValueChanged.AddListener(CambiarBrillo);

        CambiarBrillo(sliderBrillo.value);
    }

    public void CambiarBrillo(float valor)
    {
        Color color = panelBrillo.color;

        // 1 = brillo máximo, 0 = pantalla oscura
        color.a = 1f - valor;

        panelBrillo.color = color;
    }
}