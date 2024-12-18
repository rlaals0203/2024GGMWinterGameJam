using UnityEngine;
using DG.Tweening;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private PlayerDead _playerDead;

    private GameObject _gameOverUI;

    private void Awake()
    {
        _playerDead.OnCutSceneEnd += HandlePlayerDead;

        _gameOverUI = transform.Find("background").gameObject;
        _gameOverUI.SetActive(false);
    }

    private void OnDisable()
    {
        _playerDead.OnCutSceneEnd -= HandlePlayerDead;
    }

    private void HandlePlayerDead()
    {
        _gameOverUI.SetActive(true);
        _gameOverUI.transform.DOMoveY(540, 1f).SetEase(Ease.OutExpo);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {

    }

    public void Retry()
    {
        _gameOverUI.transform.DOMoveY(540, 1f).SetEase(Ease.OutExpo)
            .OnComplete(() =>
        {
            _gameOverUI.SetActive(false);
        });
    }
}
