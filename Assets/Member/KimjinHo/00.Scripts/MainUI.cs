using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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


    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    [SerializeField] private List<GameObject> buttons; // 여러 버튼들을 담을 리스트
    private GameObject currentHoveredButton = null;   // 현재 마우스가 오버된 버튼

    private void OnEnable()
    {
        StartMove();
    }

    private void StartMove()
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

    private void Update()
    {
        OnMouse();
    }

    private void OnMouse()
    {
        GameObject hoveredButton = GetHoveredButton();

        if (hoveredButton != currentHoveredButton)
        {
            currentHoveredButton = hoveredButton;

            foreach (GameObject button in buttons)
            {
                if (button == currentHoveredButton)
                    button.transform.DOScale(1.5f, 0.3f);
                else if (button != currentHoveredButton)
                    button.transform.DOScale(0.5f, 0.3f);
            }
        }

        if (currentHoveredButton == null)
        {
            foreach (GameObject button in buttons)
            {
                button.transform.DOScale(1f, 0.3f);
            }
        }
    }


    private GameObject GetHoveredButton()
    {
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            foreach (GameObject button in buttons)
            {
                if (result.gameObject == button)
                    return button;
            }
        }
        return null;
    }

}