using DG.Tweening;
using System.Collections;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    private Vector2 moveDir;
    private Transform _directionTrm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
/*            _directionTrm = bullet.transform.Find("Direction");
            moveDir = (_directionTrm.position - bullet.transform.position).normalized;*/
            PlayEffect(bullet.transform);
            StartCoroutine(SlowMotionRoutine());
            bullet.CameraPos.transform.DOShakePosition(0.25f, 25, 50, 5f);
        }
    }

    private void PlayEffect(Transform playerTrm)
    {
        EffectPlayer effect = PoolManager.Instance.Pop("WallBreakParticle") as EffectPlayer;
        effect.SetPositionAndPlay(playerTrm.position);
    }

    private IEnumerator SlowMotionRoutine()
    {
        Time.timeScale = 0.8f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1f;
    }
}
