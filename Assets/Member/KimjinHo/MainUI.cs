using DG.Tweening;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _settingButton;
    [SerializeField] private GameObject _exitButton;

    [Header("TitleMovePos")]
    [SerializeField] private Transform _titlePos;
    [SerializeField] private Transform _titlePos2;
    [SerializeField] private Transform _titlePos3;

    [Header("StartButtonMovePos")]
    [SerializeField] private Transform StartButtonPos1;
    [SerializeField] private Transform StartButtonPos2;
    [SerializeField] private Transform StartButtonPos3;

    [Header("SettingButtonMovePos")]
    [SerializeField] private Transform SettingButtonPos1;
    [SerializeField] private Transform SettingButtonPos2;
    [SerializeField] private Transform SettingButtonPos3;

    [Header("ExitButtonMovePos")]
    [SerializeField] private Transform _exitButtonPos1;
    [SerializeField] private Transform _exitButtonPos2;
    [SerializeField] private Transform _exitButtonPos3;


    private void Start()
    {
        var seq = DOTween.Sequence();
        var seqbtn1 = DOTween.Sequence();
        var seqbtn2 = DOTween.Sequence();
        var seqbtn3 = DOTween.Sequence();

        seq
            .Prepend(_title.transform.DOMove(_titlePos2.position, 0.5f))
            .Append(_title.transform.DOMove(_titlePos3.position, 0.5f))
            .Append(_title.transform.DOMove(_titlePos.position, 0.4f));

        seqbtn1
            .Insert(1.4f, _startButton.transform.DOMove(StartButtonPos3.position, 0.5f))
            .Append(_startButton.transform.DOMove(StartButtonPos2.position, 0.5f))
            .Append(_startButton.transform.DOMove(StartButtonPos1.position, 0.4f));
        seqbtn2
            .Insert(2.4f, _settingButton.transform.DOMove(SettingButtonPos3.position, 0.5f))
            .Append(_settingButton.transform.DOMove(SettingButtonPos2.position, 0.5f))
            .Append(_settingButton.transform.DOMove(SettingButtonPos1.position, 0.4f));
        seqbtn3
            .Insert(3.4f, _exitButton.transform.DOMove(_exitButtonPos3.position, 0.5f))
            .Append(_exitButton.transform.DOMove(_exitButtonPos2.position, 0.5f))
            .Append(_exitButton.transform.DOMove(_exitButtonPos1.position, 0.4f));
    }
}