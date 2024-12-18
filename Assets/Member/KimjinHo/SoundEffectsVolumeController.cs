using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider sfxSlider; // ȿ���� �����̴�
    public SoundChannel sfxSound; // ȿ���� ����� �ҽ�

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
            sfxSource.volume = volume; // ��� ȿ���� �ҽ��� ���� ����
        }
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._sfx.clip = clip;
    }
}