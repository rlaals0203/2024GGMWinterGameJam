using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

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
        Cursor.visible = true;

    }

    public void Next()
    {
        Cursor.visible = false;
        StageManager.Instance.LoadStage();
    }

    public void Retry()
    {
        Cursor.visible = false;

        _gameSucessUI.transform.DOMoveY(1540, 1f).SetEase(Ease.OutExpo)
            .OnComplete(() =>
            {
                _gameSucessUI.SetActive(false);
            });
    }
}
