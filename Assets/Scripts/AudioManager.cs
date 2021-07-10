using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer mixer;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        var masterVol = PlayerPrefs.GetFloat("Master_Volume");
        var bgmVol = PlayerPrefs.GetFloat("BGM_Volume");
        var sfxVol = PlayerPrefs.GetFloat("SFX_Volume");
        mixer.SetFloat("Master", Mathf.Log10(masterVol) * 20);
        mixer.SetFloat("BGM", Mathf.Log10(bgmVol) * 20);
        mixer.SetFloat("SFX", Mathf.Log10(sfxVol) * 20);

    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void ToggleMuteMaster(bool isMute)
    {
        float vol = 0;
        if (isMute)
        {
            vol = -80f;
            mixer.SetFloat("Master", vol);
        }
        else
        {
            mixer.SetFloat("Master", vol);
        }
        PlayerPrefs.SetFloat("Master_Volume", vol);
    }

    public void ToggleMuteBGM(bool isMute)
    {
        float vol = 0;
        if (isMute)
        {
            vol = -80f;
            mixer.SetFloat("BGM", vol);
        }
        else
        {
            mixer.SetFloat("BGM", vol);
        }
        PlayerPrefs.SetFloat("BGM_Volume", vol);

    }

    public void ToggleMuteSFX(bool isMute)
    {
        float vol = 0;
        if (isMute)
        {
            vol = -80f;
            mixer.SetFloat("SFX", vol);
        }
        else
        {
            mixer.SetFloat("SFX", vol);
        }
        PlayerPrefs.SetFloat("SFX_Volume", vol);

    }
    public void SetMasterVol(float vol)
    {
        mixer.SetFloat("Master", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("Master_Volume", Mathf.Log10(vol) * 20);

    }

    public void SetBGMVol(float vol)
    {
        mixer.SetFloat("BGM", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("BGM_Volume", Mathf.Log10(vol) * 20);
    }

    public void SetSFXVol(float vol)
    {
        mixer.SetFloat("SFX", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("SFX_Volume", Mathf.Log10(vol) * 20);
    }
}
