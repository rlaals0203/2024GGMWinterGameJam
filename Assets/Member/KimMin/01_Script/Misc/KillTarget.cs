using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class KillTarget : MonoBehaviour
{
    public event Action OnKillEvent;
    public event Action OnKillCutSceneEnd;

    [SerializeField] private Sprite _aftermath;
    private SpriteRenderer _renderer;
    private Bullet _bullet;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Bullet bullet))
        {
            _bullet = bullet;
            OnKillCutSceneEnd += bullet.HandleKillTarget;
            Time.timeScale = 0.5f;

            _bullet.cutScene.gameObject.SetActive(true);
            _bullet.cutScene.DOFade(1f, 0f);
            _bullet.cutScene.color = Color.red;
            _bullet.cutScene.DOColor(Color.black, 0.5f);

            _renderer.sprite = _aftermath;

            ExplosionPlayer();
            StartCoroutine(CutSceneRoutine());
        }
    }

    private void OnDisable()
    {
        if (_bullet != null)
            OnKillEvent -= _bullet.HandleKillTarget;
    }

    private void ExplosionPlayer()
    {
        _bullet.VisualCompo.renderer.enabled = false;
        _bullet.RigidCompo.velocity = Vector2.zero;
        _bullet.RigidCompo.simulated = false;

        EffectPlayer _effectPlayer = PoolManager.Instance.Pop("KillParticle") as EffectPlayer;
        _effectPlayer.SetPositionAndPlay(transform.position);
    }

    private IEnumerator CutSceneRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        _bullet.cutScene.DOFade(0f, 0.5f)
            .OnComplete(() =>
            {
                OnKillCutSceneEnd?.Invoke();
            });
    }
}
