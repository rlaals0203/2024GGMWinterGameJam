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
        // ������Ʈ�� ���� ��ġ�� �ʱ�ȭ
        _block.transform.position = _movePos.position;

        // Dotween���� �̵� ����
        _block.transform.DOMove(_backPos.position, duration)
                 .SetEase(Ease.InOutSine) // �ε巴�� �̵�
                 .SetLoops(-1, LoopType.Yoyo); // ���� �ݺ��ϸ� �Դٰ���
    }
}