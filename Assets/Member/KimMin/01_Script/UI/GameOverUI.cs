using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private Player _player;

    private PlayerDead _playerDead;
    private Bullet _bullet;
    private GameObject _gameOverUI;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _bullet = _player as Bullet;
        _playerDead = _player.GetComponent<PlayerDead>();

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
        Cursor.visible = true;
    }

    public void Exit()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("Title");
    }

    public void Retry()
    {
        Cursor.visible = false;

        _gameOverUI.transform.DOMoveY(1540, 1f).SetEase(Ease.OutExpo)
            .OnComplete(() =>
        {
            _gameOverUI.SetActive(false);
            _bullet.ResetBullet();
        });
    }
}
