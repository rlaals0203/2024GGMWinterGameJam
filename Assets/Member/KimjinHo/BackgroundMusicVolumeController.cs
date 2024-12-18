using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider bgMusicSlider; // 배경 음악 슬라이더
    public SoundChannel bgSound; // 배경 음악 오디오 채널
    public AudioSource bgMusicSource; // 배경 음악 오디오 소스

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
        bgMusicSource.volume = volume; // 배경 음악 소스의 음량 조절
    }
    public void SoundPlay(AudioClip clip)
    {
        soundManager._bgm.clip = clip;
    }
}