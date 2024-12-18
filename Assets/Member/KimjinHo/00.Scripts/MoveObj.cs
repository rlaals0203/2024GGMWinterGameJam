using DG.Tweening;
using UnityEngine;

public class MoveObj : MonoBehaviour
{

    private Transform _movePos;
    private Transform _backPos;
    private Transform _block;
    [SerializeField] private float duration = 1f;

    private void Awake()
    {
        _movePos = transform.Find("StartPos");
        _backPos = transform.Find("EndPos");
        _block = transform.Find("Block");

        Move();
    }

    private void Move()
    {
        // 오브젝트를 시작 위치로 초기화
        _block.transform.position = _movePos.position;

        // Dotween으로 이동 설정
        _block.transform.DOMove(_backPos.position, duration)
                 .SetEase(Ease.InOutSine) // 부드럽게 이동
                 .SetLoops(-1, LoopType.Yoyo); // 무한 반복하며 왔다갔다
    }
}