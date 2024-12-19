using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    [SerializeField] private string _gmaeScnenName1;

    [SerializeField] private string _gmaeScnenName2;

    [SerializeField] private Image _panel;

    public static Action OnAnime;

    private bool _setting = true;

    private void Awake()
    {
        _settingPanel.SetActive(false);
    }

    private void OnEnable()
    {
        FadeIn();
    }
    private void FadeIn()
    {
        _panel.DOFade(0, 1f).OnComplete(() => _panel.gameObject.SetActive(false));
    }

    public void FadeOut()
    {
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, 1f).OnComplete(() => ChangeStartScene());
    }
    public void FadeOut2()
    {
        OnAnime?.Invoke();
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, 2f).OnComplete(() => ChangeGameScene());
    }

    public void ChangeGameScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(_gmaeScnenName1);
    }

    public void ChangeStartScene()
    {
        DOTween.KillAll();
        if (_gmaeScnenName1 != null)
            SceneManager.LoadScene(_gmaeScnenName2);
    }

    public void OnSetting()
    {
        if (_setting)
            Show();
        else
            Hide();
        _setting = !_setting;
    }
    public void Show()
    {
        if (_settingPanel == null || _settingPanel.transform == null)
            return;

        _settingPanel.SetActive(true);

        var seq = DOTween.Sequence();
        seq.Append(_settingPanel.transform.DOScale(1.1f, 0.5f));
        seq.Append(_settingPanel.transform.DOScale(1f, 0.1f));
        seq.Play();
    }

    public void Hide()
    {
        if (_settingPanel == null || _settingPanel.transform == null)
            return;

        var seq = DOTween.Sequence();

        _settingPanel.transform.localScale = Vector3.one * 0.2f;
        seq.Append(_settingPanel.transform.DOScale(1.1f, 0.1f));
        seq.Append(_settingPanel.transform.DOScale(0f, 0.5f));
        seq.Play().OnComplete(() =>
        {
            _settingPanel?.SetActive(false);
        });
    }

    public void OnGameExit()
    {
        Application.Quit();
    }

}