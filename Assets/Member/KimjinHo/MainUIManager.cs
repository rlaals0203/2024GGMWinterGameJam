using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    [SerializeField] private string _gmaeScnenName;

    [SerializeField] private TMP_Dropdown _dropdown;

    [SerializeField] private AudioSource _aa;

    [Header("Sound")]
    [SerializeField] private SoundChannelSO _musicSound;
    [SerializeField] private SoundChannelSO _effectSound;

    [SerializeField] private SoundManager _soundManager;

    private bool _setting = true;

    private void Awake()
    {
        _settingPanel.SetActive(false);
        _musicSound.players[0] = _aa;
        _musicSound.players[0].Play();
    }

    public void ChangeScene()
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

    private void MasterSlider(float changeEvent)
    {
        float newVolume = changeEvent / 100f; // 0~100 범위 -> 0~1로 변환
        _musicSound.UpdateVolume(newVolume);
        _effectSound.UpdateVolume(newVolume);
        PlayerPrefs.SetFloat("MasterVolume", newVolume);
    }

    private void MusicSlider(float changeEvent)
    {
        // 사운드 세팅
        float newVolume = changeEvent / 100f;
        _musicSound.UpdateVolume(newVolume);
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
    }

    private void EffectSlider(float changeEvent)
    {
        // 사운드 세팅
        float newVolume = changeEvent / 100f;
        _effectSound.UpdateVolume(newVolume); ;
        PlayerPrefs.SetFloat("EffectVolume", newVolume);
    }
}