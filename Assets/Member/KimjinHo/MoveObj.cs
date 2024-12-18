using DG.Tweening;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveObj : MonoBehaviour
{

    [SerializeField] private Transform _movePos;
    [SerializeField] private Transform _backPos;
    [SerializeField] private float duration = 1f;
    private void Awake()
    {
        Move();
    }

    private void Move()
    {
        // 오브젝트를 시작 위치로 초기화
        transform.position = _movePos.position;

        // Dotween으로 이동 설정
        transform.DOMove(_backPos.position, duration)
                 .SetEase(Ease.InOutSine) // 부드럽게 이동
                 .SetLoops(-1, LoopType.Yoyo); // 무한 반복하며 왔다갔다
    }
}