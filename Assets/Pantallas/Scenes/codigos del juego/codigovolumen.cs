using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    /// <summary>
    /// Slider que controla el volumen de la música
    /// </summary>
    public Slider volumeSlider;

    /// <summary>
    /// AudioSource donde se reproduce la música
    /// </summary>
    public AudioSource musicSource;

    /// <summary>
    /// Se ejecuta al iniciar el juego
    /// </summary>
    void Start()
    {
        volumeSlider.value = musicSource.volume;

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    /// <summary>
    /// Cambia el volumen según el valor del Slider
    /// </summary>
    /// <param name="value">
    /// Valor del Slider entre 0 y 1
    /// </param>
    void ChangeVolume(float value)
    {
        musicSource.volume = value;
    }
}