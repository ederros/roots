using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private float _volumeValue;
    public string volumeParametr = "MasterVolume";
    public AudioMixer audioMixer;
    public Slider slider;
    private const float _multipler = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        PlayerPrefs.GetFloat(volumeParametr, _volumeValue);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multipler;
        audioMixer.SetFloat(volumeParametr, _volumeValue);

    }

    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParametr, 1);
        slider.value = Mathf.Pow(10f, _volumeValue / _multipler);
    }

    public void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParametr, _multipler);
        PlayerPrefs.SetFloat(volumeParametr, _volumeValue);
        PlayerPrefs.Save();
    }
}