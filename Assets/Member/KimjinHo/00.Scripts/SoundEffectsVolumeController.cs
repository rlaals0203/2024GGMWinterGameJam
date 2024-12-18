using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider sfxSlider; // 효과음 슬라이더
    public SoundChannel sfxSound; // 효과음 오디오 소스

    private string sfxName = "SFX";

    private void Start()
    {

        float volume = PlayerPrefs.GetFloat(sfxName);
        sfxSlider.value = volume;
        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = volume; // Sound 객체의 볼륨 설정
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = volume; // AudioSource 볼륨 설정
            PlayerPrefs.SetFloat(sfxName, volume);
        }

        SetSound(soundManager._sfx);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        SoundPlay(sfxSound.sounds[0].clip);
    }

    public void SetSound(AudioSource audioSource)
    {
        foreach (var bgmSource in sfxSound.sounds)
            bgmSource.audioSource = audioSource;
    }

    private void SetSFXVolume(float volume)
    {
        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = volume; // Sound 객체의 볼륨 설정
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = volume; // AudioSource 볼륨 설정
            PlayerPrefs.SetFloat(sfxName, volume);
        }
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._sfx.clip = clip;
        soundManager._sfx.Play();
    }
}