using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;

    [SerializeField] private string _gmaeScnenName;

    private bool _setting = true;

    private void Awake()
    {
        _settingPanel.SetActive(false);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(_gmaeScnenName);
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
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }
    }
}