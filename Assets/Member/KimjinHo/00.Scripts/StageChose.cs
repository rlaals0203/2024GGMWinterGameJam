using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChose : Hover
{
    [Header("MovePosition")]
    [SerializeField] private Transform[] _inStatePos;
    [SerializeField] private Transform[] _outStatePos;

    [SerializeField] private GameObject[] Locks;

    private Image _panel;

    public static Action OnUnLock;

    public void OnStageClick(int stageNumber)
    {
        if (StageManager.Instance.maxStage >= stageNumber + 1)
        {
            StageManager.Instance.maxStage = stageNumber + 1;
            FadeOut($"Stage{stageNumber + 1}");
            OutMove();
        }
    }

    public void OnUnlock()
    {
        OnUnLock?.Invoke();
        if (StageManager.Instance.maxStage >= 8)
        {
            for (int i = 0; i < 8; i++)
            {
                Locks[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < StageManager.Instance.maxStage; i++)
            {
                Locks[i].gameObject.SetActive(false);
            }
        }
    }

    public void ChangeStartScene()
    {
        _panel.gameObject.SetActive(true);
        _panel.DOFade(1, 1f).OnComplete(() => ChangeGameScene("Title"));
    }

    public void FadeOut(string str)
    {
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
        OnUnlock();
        InMove();
    } 

    private void Awake()
    {
        _panel = transform.Find("Fade").GetComponent<Image>();
    }

    private void Start()
    {
        //foreach (GameObject button in Button)
        //{
        //    Button btn = button.GetComponent<Button>();
        //    btn.onClick.AddListener(OutMove);
        //}
    }

    private void OutMove()
    {
        var seq = DOTween.Sequence();
        for (int i = 0; i < Button.Count; i++)
            if (i < _outStatePos.Length)
                seq.Append(Button[i].transform.DOMove(_outStatePos[i].position, 0.2f)).SetEase(Ease.InQuad);
        DOTween.Kill(seq);
    }

    private void InMove()
    {
        var seq = DOTween.Sequence();
        for (int i = 0; i < Button.Count; i++)
            if (i < _inStatePos.Length)
                seq.Append(Button[i].transform.DOMove(_inStatePos[i].position, 0.2f)).SetEase(Ease.InQuad);
        DOTween.Kill(seq);
    }

    private void Update() => OnMouse();
}