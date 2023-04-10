using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour {

    public AudioSource sfxAudios;
    public AudioSource auxSfxAudios;
    public AudioSource auxSfxAudios2;
    public AudioSource continuousSfxAudios;
    public AudioSource bgMusic;
    public AudioSource bgSFXLoop;
    public AudioSource bgSFX;

    public static ControlaAudio instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public float volumeMusica = 1, volumeEfeitos = 1;

    public float VolumeMusica
    {
        get {
            return volumeMusica;
        }
        set {
            volumeMusica = value;
        }
    }

    public float VolumeEfeitos
    {
        get
        {
            return volumeEfeitos;
        }
        set
        {
            volumeEfeitos = value;
        }
    }

    public void AplicarVolume()
    {
        bgMusic.volume = volumeMusica;

        sfxAudios.volume = volumeEfeitos;
        auxSfxAudios.volume = volumeEfeitos;
        auxSfxAudios2.volume = volumeEfeitos;
        bgSFX.volume = volumeEfeitos;
        bgSFXLoop.volume = volumeEfeitos;
        continuousSfxAudios.volume = volumeEfeitos;
    }

    public void TocaMusica(AudioClip musica)
    {
        bgMusic.clip = musica;
        bgMusic.Play();
    }

    public void TocaEfeitoDeFundoLoop(AudioClip efeitoFundo)
    {
        bgSFXLoop.clip = efeitoFundo;
        bgSFXLoop.Play();
    }

    public void TocaEfeitoDeFundo(AudioClip efeitoFundo)
    {
        bgSFX.clip = efeitoFundo;
        bgSFX.pitch = Random.Range(0.8f, 1.2f);
        bgSFX.Play();
    }

    public void TocaAudio(AudioClip audio)
    {
        if (!sfxAudios.isPlaying)
        {
            sfxAudios.clip = audio;
            sfxAudios.Play();
        }
        else if (!auxSfxAudios.isPlaying)
        {
            auxSfxAudios.clip = audio;
            auxSfxAudios.Play();
        }
        else
        {
            auxSfxAudios2.clip = audio;
            auxSfxAudios2.Play();
        }

    }

    public void TocaAudioLoop(AudioClip audio)
    {
        continuousSfxAudios.clip = audio;
        continuousSfxAudios.Play();
    }
    public void ParaAudioLoop()
    {
        continuousSfxAudios.Stop();
    }

    public void ParaAudios()
    {
        sfxAudios.Stop();
        auxSfxAudios.Stop();
        continuousSfxAudios.Stop();
        bgMusic.Stop();
        bgSFX.Stop();
        bgSFXLoop.Stop();
    }

    public void PausaAudios(bool condition)
    {
        if (condition)
        {
            sfxAudios.Pause();
            auxSfxAudios.Pause();
            auxSfxAudios2.Pause();
            continuousSfxAudios.Pause();
        }
        else
        {
            sfxAudios.UnPause();
            auxSfxAudios.UnPause();
            auxSfxAudios2.UnPause();
            continuousSfxAudios.UnPause();
        }
    }
}
