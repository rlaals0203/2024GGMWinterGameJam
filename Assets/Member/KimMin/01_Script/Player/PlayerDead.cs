using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour, IPlayerComponent
{
    public event Action OnDeadEvent;
    public event Action OnCutSceneEnd;

    private Bullet _bullet;
    private EffectPlayer _effectPlayer;

    public void Initialize(Player player)
    {
        _bullet = player as Bullet;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out ICollisionable collisionable) ||
            collision.transform.CompareTag("Wall"))
        {
            KillPlayer();
        }

    }

    public void KillPlayer()
    {
        _bullet.CameraPos.transform.DOShakePosition(1f, 4f);

        _bullet.cutScene.gameObject.SetActive(true);
        _bullet.cutScene.DOFade(1f, 0f);

        ExplosionPlayer();
        StartCoroutine(CutSceneRoutine());
        OnDeadEvent?.Invoke();
    }

    private void ExplosionPlayer()
    {
        DOTween.To(() => 0.2f, x => Time.timeScale = x, 1f, 0.3f)
            .SetEase(Ease.InBack);

        _bullet.VisualCompo.renderer.enabled = false;
        _bullet.RigidCompo.velocity = Vector2.zero;
        _bullet.RigidCompo.angularVelocity = 0;
        _bullet.RigidCompo.simulated = false;

        AudioManager.Instance.PlaySound("BulletBroke");
        _effectPlayer = PoolManager.Instance.Pop("ExplosionParticle") as EffectPlayer;
        _effectPlayer.SetPositionAndPlay(transform.position);
    }

    private IEnumerator CutSceneRoutine()
    {
        yield return new WaitForSeconds(1f);

        _bullet.cutScene.DOFade(0f, 0.5f)
            .OnComplete(() =>
        {
            OnCutSceneEnd?.Invoke();
        });
    }
}
