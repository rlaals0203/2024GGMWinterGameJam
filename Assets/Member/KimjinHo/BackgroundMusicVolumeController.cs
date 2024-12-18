using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider bgMusicSlider; // ��� ���� �����̴�
    public SoundChannel bgSound; // ��� ���� ����� ä��
    public AudioSource bgMusicSource; // ��� ���� ����� �ҽ�

    private string bgmName = "BGM";

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat(bgmName);
        bgMusicSlider.value = volume;
        foreach (var sfxSource in bgSound.sounds)
        {
            sfxSource.volume = volume; // Sound ��ü�� ���� ����
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = volume; // AudioSource ���� ����
            PlayerPrefs.SetFloat(bgmName, volume);
        }

        SetSound(soundManager._bgm);
        bgMusicSlider.onValueChanged.AddListener(SetBackgroundMusicVolume);
        SoundPlay(bgSound.sounds[0].clip);
        bgSound.sounds[0].SoundPlay();
    }

    public void SetSound(AudioSource audioSource)
    {
        foreach (var bgmSource in bgSound.sounds)
            bgmSource.audioSource = audioSource;

    }

    void SetBackgroundMusicVolume(float volume)
    {
        bgMusicSource.volume = volume; // ��� ���� �ҽ��� ���� ����
        if (bgmName != null)
            PlayerPrefs.SetFloat(bgmName, volume);
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._bgm.clip = clip;
    }
}