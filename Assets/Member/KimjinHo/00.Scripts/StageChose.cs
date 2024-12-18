using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageChose : MonoBehaviour
{
    [Header("ScaneName")]
    [SerializeField] private string[] _scaneName;

    [Header("MovePosition")]
    [SerializeField] private Transform[] _inStatePos;
    [SerializeField] private Transform[] _outStatePos;

    [Header("MoveObject")]
    [SerializeField] private List<GameObject> _stageButton;

    [SerializeField] private Image _panel;

    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    private GameObject currentHoveredButton = null;


    public void OnStageClick(int stageNumber)
    {
        if (stageNumber >= 0 && stageNumber < _scaneName.Length)
            FadeOut(_scaneName[stageNumber]);
    }

    public void FadeOut(string str)
    {
        Debug.Log(str);
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, 1f).OnComplete(() => ChangeGameScene(str));
    }

    public void ChangeGameScene(string str)
    {
        DOTween.KillAll();
        SceneManager.LoadScene(str);
    }

    private void OnEnable()
    {
        InMove();
    }
    private void Start()
    {
        foreach (GameObject button in _stageButton)
        {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(OutMove);
        }
    }

    private void OutMove()
    {
        var seq = DOTween.Sequence();
        for (int i = 0; i < _stageButton.Count; i++)
        {
            if (i < _outStatePos.Length)
            {
                seq.Append(_stageButton[i].transform.DOMove(_outStatePos[i].position, 0.2f));
            }
        }
    }

    private void InMove()
    {
        var seq = DOTween.Sequence();
        for (int i = 0; i < _stageButton.Count; i++)
        {
            if (i < _inStatePos.Length)
            {
                seq.Append(_stageButton[i].transform.DOMove(_inStatePos[i].position, 0.2f));
            }
        }
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

            foreach (GameObject button in _stageButton)
            {
                if (button == null) continue;

                if (button == currentHoveredButton)
                    button.transform.DOScale(1.5f, 0.3f);
                else
                    button.transform.DOScale(0.8f, 0.3f);
            }
        }

        if (currentHoveredButton == null)
        {
            foreach (GameObject button in _stageButton)
            {
                if (button == null) continue;

                button.transform.DOScale(1f, 0.3f);
            }
        }
    }



    private GameObject GetHoveredButton()
    {
        if (graphicRaycaster == null || eventSystem == null)
        {
            return null;
        }

        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            foreach (GameObject button in _stageButton)
            {
                if (result.gameObject == button)
                    return button;
            }
        }

        return null;
    }
}