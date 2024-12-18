using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public Slider bgMusicSlider; // 배경 음악 슬라이더
    public SoundChannel bgSound; // 배경 음악 오디오 채널
    public AudioSource bgMusicSource; // 배경 음악 오디오 소스

    private string bgmName = "BGM";

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat(bgmName);
        bgMusicSlider.value = volume;
        foreach (var sfxSource in bgSound.sounds)
        {
            sfxSource.volume = volume; // Sound 객체의 볼륨 설정
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = volume; // AudioSource 볼륨 설정
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
        bgMusicSource.volume = volume; // 배경 음악 소스의 음량 조절
        if (bgmName != null)
            PlayerPrefs.SetFloat(bgmName, volume);
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._bgm.clip = clip;
    }
}