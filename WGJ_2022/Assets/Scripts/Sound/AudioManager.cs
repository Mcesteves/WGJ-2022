using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.Audio;
using Debug = UnityEngine.Debug;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] soundEffects;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.GetInt("FirstGame") == 0)
        {
            PlayerPrefs.SetFloat("MasterVolume", 50f);
            PlayerPrefs.SetFloat("MusicVolume", 50f);
            PlayerPrefs.SetFloat("SFXVolume", 50f);
            PlayerPrefs.SetInt("FirstGame", 1);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = PlayerPrefs.GetFloat("MusicVolume") * 0.01f * PlayerPrefs.GetFloat("MasterVolume") * 0.01f;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach (Sound s in soundEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = PlayerPrefs.GetFloat("SFXMusic") * 0.01f * PlayerPrefs.GetFloat("MasterVolume") * 0.01f;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        UpdateSoundVolumes();
    }

    private void Start()
    {
        //Play("TesteMusica");//teste do sistema de configuracoes de som
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
            return;
        }
        s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Stop();
            return;
        }
        s = Array.Find(soundEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    public void StopAllMusicSounds()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }
    public void StopAllEffectsSounds()
    {
        foreach (Sound sound in soundEffects)
        {
            sound.source.Stop();
        }
    }
    public void UpdateSoundVolumes()
    {
        foreach (Sound s in sounds)
            s.source.volume = PlayerPrefs.GetFloat("MusicVolume") * PlayerPrefs.GetFloat("MasterVolume") * 0.0001f;
        foreach (Sound s in soundEffects)
            s.source.volume = PlayerPrefs.GetFloat("SFXVolume") * PlayerPrefs.GetFloat("MasterVolume") * 0.0001f;
    }
}
