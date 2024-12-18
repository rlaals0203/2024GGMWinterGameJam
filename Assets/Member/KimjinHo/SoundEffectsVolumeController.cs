using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider sfxSlider; // 효과음 슬라이더
    public SoundChannel sfxSound; // 효과음 오디오 소스

    private void Start()
    {
        SetSound(soundManager._sfx);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    public void SetSound(AudioSource audioSource)
    {
        foreach (var bgmSource in sfxSound.sounds)
        {
            bgmSource.audioSource = audioSource;
        }
    }
    private void SetSFXVolume(float volume)
    {
        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = volume; // 모든 효과음 소스의 음량 조절
        }
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._sfx.clip = clip;
    }
}