using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    bool _istrue = false;

    [SerializeField] private GameObject _gameObject;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Panel(_istrue);
    }

    private void Panel(bool istrue)
    {
        if (istrue)
            Hide();
        else
            Show();
    }
    public void Show()
    {
        if (_gameObject == null || _gameObject.transform == null)
            return;

        _gameObject.SetActive(true);

        var seq = DOTween.Sequence();
        seq.Append(_gameObject.transform.DOScale(1.9f, 0.5f));
        seq.Append(_gameObject.transform.DOScale(1.8f, 0.1f));
        seq.Play();
        _istrue = true;
    }


    public void Hide()
    {
        if (_gameObject == null || _gameObject.transform == null)
            return;

        var seq = DOTween.Sequence();

        _gameObject.transform.localScale = Vector3.one * 0.2f;
        seq.Append(_gameObject.transform.DOScale(1.8f, 0.1f));
        seq.Append(_gameObject.transform.DOScale(0f, 0.5f));
        seq.Play().OnComplete(() =>
        {
            _gameObject?.SetActive(false);
        });
        _istrue = false;
    }

    public void FadeOut1()
    {
        ChangeStartScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    public void ChangeStartScene()
    {
        Destroy(_gameObject);
        DOTween.KillAll();
        if (_sceneName != null)
            SceneManager.LoadScene(_sceneName);
    }
}