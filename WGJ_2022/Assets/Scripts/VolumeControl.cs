using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private static string _masterVolume = "MasterVolume";
    private static string _sfxVolume = "SFXVolume";
    private static string _musicVolume = "MusicVolume";

    private float _soundValue;
    private Slider _slider;

    void Start()
    {
        _slider = this.GetComponent<Slider>();
        SetSoundPrefs();
    }

    public void SetSoundPrefs()
    {
        if (PlayerPrefs.GetInt("FirstGame") != 0)
        {
            if (_slider.tag == _masterVolume)
                _soundValue = PlayerPrefs.GetFloat(_masterVolume);
            else if (_slider.tag == _musicVolume)
                _soundValue = PlayerPrefs.GetFloat(_musicVolume);
            else
                _soundValue = PlayerPrefs.GetFloat(_sfxVolume);
        }
        _slider.value = _soundValue;
    }

    public void SetVolume()
    {
        if (_slider.tag == _masterVolume)
            PlayerPrefs.SetFloat(_masterVolume, _slider.value);    
        else if (_slider.tag == _musicVolume)
            PlayerPrefs.SetFloat(_musicVolume, _slider.value);
        else
            PlayerPrefs.SetFloat(_sfxVolume, _slider.value);
        AudioManager.instance.UpdateSoundVolumes();
    }

}