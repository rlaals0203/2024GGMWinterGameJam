using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainUI : Hover
{
    [Header("UI")]
    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _settingButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private Image _panel;


    [Header("TitleMovePos")]
    [SerializeField] private Transform _titlePos1;
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

    [SerializeField] private Transform _titlePos;
    [SerializeField] private Transform _Pos1;
    [SerializeField] private Transform _pos2;

    private void Awake() => DOTween.SetTweensCapacity(500, 50);

    private void OnEnable()
    {
        MainUIManager.OnAnime += EndMove;
        _panel.DOFade(0, 1f);
        StartMove();
    }

    private void OnDisable() => MainUIManager.OnAnime -= EndMove;
    private void StartMove()
    {
        var seq = DOTween.Sequence();
        var seqbtn1 = DOTween.Sequence();
        var seqbtn2 = DOTween.Sequence();
        var seqbtn3 = DOTween.Sequence();

        seq
            .Prepend(_title.transform.DOMove(_titlePos2.position, 0.6f)).SetEase(Ease.OutBounce)
            .Append(_title.transform.DOMove(_titlePos3.position, 0.5f))
            .Append(_title.transform.DOMove(_titlePos1.position, 0.4f));

        seqbtn1
            .Insert(1.4f, _startButton.transform.DOMove(StartButtonPos3.position, 0.5f)).SetEase(Ease.OutBounce)
            .Append(_startButton.transform.DOMove(StartButtonPos2.position, 0.5f))
            .Append(_startButton.transform.DOMove(StartButtonPos1.position, 0.4f));

        seqbtn2
            .Insert(2f, _settingButton.transform.DOMove(SettingButtonPos3.position, 0.5f)).SetEase(Ease.OutBounce)
            .Append(_settingButton.transform.DOMove(SettingButtonPos2.position, 0.5f))
            .Append(_settingButton.transform.DOMove(SettingButtonPos1.position, 0.4f));

        seqbtn3
            .Insert(2.6f, _exitButton.transform.DOMove(_exitButtonPos3.position, 0.5f)).SetEase(Ease.OutBounce)
            .Append(_exitButton.transform.DOMove(_exitButtonPos2.position, 0.5f))
            .Append(_exitButton.transform.DOMove(_exitButtonPos1.position, 0.4f));
    }

    public void EndMove()
    {
        var seq = DOTween.Sequence();
        var seqbtn1 = DOTween.Sequence();
        var seqbtn2 = DOTween.Sequence();
        var seqbtn3 = DOTween.Sequence();

        seq
            .Prepend(_title.transform.DOMove(_titlePos.position, 2f)).SetEase(Ease.OutBounce);

        seqbtn1
            .Insert(0f, _startButton.transform.DOMove(SettingButtonPos2.position, 0.6f)).SetEase(Ease.OutBounce)
            .Append(_startButton.transform.DOMove(_exitButtonPos2.position, 0.4f)).SetEase(Ease.OutBounce)
            .Append(_startButton.transform.DOMove(_Pos1.position, 0.4f)).SetEase(Ease.OutBounce)
            .Append(_startButton.transform.DOMove(_pos2.position, 0.4f)).SetEase(Ease.OutBounce);

        seqbtn2
            .Insert(0.5f, _settingButton.transform.DOMove(_exitButtonPos2.position, 0.6f)).SetEase(Ease.OutBounce)
            .Append(_settingButton.transform.DOMove(_Pos1.position, 0.4f)).SetEase(Ease.OutBounce)
            .Append(_settingButton.transform.DOMove(_pos2.position, 0.4f)).SetEase(Ease.OutBounce);

        seqbtn3
            .Insert(1f, _exitButton.transform.DOMove(_Pos1.position, 0.6f)).SetEase(Ease.OutBounce)
            .Append(_exitButton.transform.DOMove(_pos2.position, 0.4f)).SetEase(Ease.OutBounce);
    }

    private void Update()
    {
        OnMouse();
    }
}