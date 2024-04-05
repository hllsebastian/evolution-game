using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource[] music;
    public AudioSource[] soundEfectsEFX;
    public AudioMixerGroup musicMixer, sfxMixer;

    private void Awake()
    {
        instance = this;
    }
   
    void Start()
    {
        PlayMusic(1);
        
    }

    void Update()
    {

    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxPlay)
    {
        soundEfectsEFX[sfxPlay].Play();
    }

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", UIManager.instance.musicVolSlider.value);
    }

    public void SetSFXLevel()
    {
        sfxMixer.audioMixer.SetFloat("SFXVol", UIManager.instance.sfxVolSlider.value);
    }

    public float GetMusicLevel()
    {
        if (musicMixer.audioMixer.GetFloat("MusicVol", out float volume))
        {
            return volume;
        }
        return 0;
    }
    public float GetSFXLevel()
    {
        if (sfxMixer.audioMixer.GetFloat("SFXVol", out float volume))
        {
            return volume;
        }
        return 0;
    }
}

