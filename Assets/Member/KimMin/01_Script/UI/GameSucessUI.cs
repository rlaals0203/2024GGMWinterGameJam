using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class GameSucessUI : MonoBehaviour
{
    private KillTarget _killTarget;

    private PlayerDead _playerDead;
    private GameObject _gameSucessUI;

    private void Awake()
    {
        _killTarget = GameObject.Find("Target").GetComponent<KillTarget>();
        _killTarget.OnKillCutSceneEnd += HandleGameSucess;

        _gameSucessUI = transform.Find("background").gameObject;
        _gameSucessUI.SetActive(false);
    }

    private void OnDisable()
    {
        _killTarget.OnKillCutSceneEnd -= HandleGameSucess;
    }

    private void HandleGameSucess()
    {
        _gameSucessUI.SetActive(true);
        _gameSucessUI.transform.DOMoveY(540, 1f).SetEase(Ease.OutExpo);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Next()
    {
        StageManager.Instance.currentStage++;
        StageManager.Instance.LoadStage();
    }

    public void Retry()
    {
        _gameSucessUI.transform.DOMoveY(1540, 1f).SetEase(Ease.OutExpo)
            .OnComplete(() =>
            {
                _gameSucessUI.SetActive(false);
            });
    }
}
