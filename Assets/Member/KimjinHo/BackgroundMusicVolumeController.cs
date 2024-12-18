using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider bgMusicSlider; // ��� ���� �����̴�
    public SoundChannel bgSound; // ��� ���� ����� ä��
    public AudioSource bgMusicSource; // ��� ���� ����� �ҽ�

    private void Start()
    {
        SetSound(soundManager._bgm);
        bgMusicSlider.onValueChanged.AddListener(SetBackgroundMusicVolume);
        SoundPlay(bgSound.sounds[0].clip);
        bgSound.sounds[0].SoundPlay();
    }

    public void SetSound(AudioSource audioSource)
    {
        foreach (var bgmSource in bgSound.sounds)
        {
            bgmSource.audioSource = audioSource;
        }
    }

    void SetBackgroundMusicVolume(float volume)
    {
        bgMusicSource.volume = volume; // ��� ���� �ҽ��� ���� ����
    }
    public void SoundPlay(AudioClip clip)
    {
        soundManager._bgm.clip = clip;
    }
}