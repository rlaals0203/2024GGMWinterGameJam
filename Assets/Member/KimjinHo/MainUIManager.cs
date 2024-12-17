using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
using DG.Tweening;
using System.Collections.Generic;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    [SerializeField] private string _gmaeScnenName;

    [SerializeField] private TMP_Dropdown _dropdown;

    [Header("Sound")]
    [SerializeField] private SoundChannelSO _musicSound;
    [SerializeField] private SoundChannelSO _effectSound;

    private bool _setting = true;
    private Slider _masterVolumeSlider;
    private Slider _musicVolumeSlider;
    private Slider _effectVolumeSlider;

    private void Awake()
    {
        _settingPanel.SetActive(false);
    }
    public void OnGameStart()
    {
        SceneManager.LoadScene(_gmaeScnenName);
    }

    public void OnSetting()
    {
        if (_setting)
        {
            Show();
        }
        else
        {
            Hide();
        }
        _setting = !_setting;
    }
    public void Show()
    {
        _settingPanel.SetActive(true);

        var seq = DOTween.Sequence();

        seq.Append(_settingPanel.transform.DOScale(1.1f, 0.2f));
        seq.Append(_settingPanel.transform.DOScale(1f, 0.1f));

        seq.Play();
    }

    public void Hide()
    {
        var seq = DOTween.Sequence();

        _settingPanel.transform.localScale = Vector3.one * 0.2f;

        seq.Append(_settingPanel.transform.DOScale(1.1f, 0.1f));
        seq.Append(_settingPanel.transform.DOScale(0.2f, 0.2f));

        seq.Play().OnComplete(() =>
        {
            _settingPanel.SetActive(false);
        });
    }
    public void OnGameExit()
    {
        Application.Quit();
    }

    public void SetScreenMode(int index)
    {
        switch (index)
        {
            case 0: // 전체 화면
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Debug.Log("전체 화면");
                break;

            case 1: // 창 모드
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Debug.Log("창 모드");
                break;
        }
    }
    private void Initialize()
    {
        //_masterVolumeSlider.value = masterVolume;

        //_musicVolumeSlider.value = musicVolume;

        //_effectVolumeSlider.value = effectVolume;

        ////masterSound.volume = masterVolume;
        //_musicSound.volume = musicVolume;
        //_effectSound.volume = effectVolume;

    }
    public void MasterSlider(float changeEvent)
    {
        float newVolume = changeEvent / 100f; // 0~100 범위 -> 0~1로 변환
        _musicSound.UpdateVolume(newVolume);
        _effectSound.UpdateVolume(newVolume);
        _musicSound.playOnAwake = true;
        _effectSound.playOnAwake = true;
    }

    public void MusicSlider(float changeEvent)
    {
        // 사운드 세팅
        float newVolume = changeEvent / 100f;
        _musicSound.UpdateVolume(newVolume);
    }

    public void EffectSlider(float changeEvent)
    {
        // 사운드 세팅
        float newVolume = changeEvent / 100f;
        _effectSound.UpdateVolume(newVolume); ;
    }
}