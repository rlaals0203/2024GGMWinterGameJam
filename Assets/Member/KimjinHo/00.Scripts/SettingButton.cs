using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : Hover
{
    [SerializeField] private string _sceneName;

    bool _istrue = false;

    [SerializeField] private GameObject _gameObject;

    private void Awake()
    {
        
    }
    private void Update()
    {

        OnMouse();
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
        {
            SceneManager.LoadScene(_sceneName);
            Cursor.visible = true;
        }
    }

    public override void OnMouse()
    {
        GameObject hoveredButton = GetHoveredButton();

        if (hoveredButton != CurrentHoveredButton)
        {
            CurrentHoveredButton = hoveredButton;

            foreach (GameObject button in Button)
            {
                if (button == null) continue;

                if (button == CurrentHoveredButton)
                    button.transform.DOScale(1.3f, 0.3f);
                else
                    button.transform.DOScale(1f, 0.3f);
            }
        }

        if (CurrentHoveredButton == null)
        {
            foreach (GameObject button in Button)
            {
                if (button == null) continue;

                button.transform.DOScale(1f, 0.3f);
            }
        }
    }
}