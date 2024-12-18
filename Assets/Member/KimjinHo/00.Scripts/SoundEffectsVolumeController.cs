using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider sfxSlider; // ȿ���� �����̴�
    public SoundChannel sfxSound; // ȿ���� ����� �ҽ�

    private string sfxName = "SFX";

    private void Start()
    {

        float volume = PlayerPrefs.GetFloat(sfxName);
        sfxSlider.value = volume;
        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = volume; // Sound ��ü�� ���� ����
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = volume; // AudioSource ���� ����
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
            sfxSource.volume = volume; // Sound ��ü�� ���� ����
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = volume; // AudioSource ���� ����
            PlayerPrefs.SetFloat(sfxName, volume);
        }
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._sfx.clip = clip;
        soundManager._sfx.Play();
    }
}