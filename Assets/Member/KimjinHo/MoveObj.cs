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
        // ������Ʈ�� ���� ��ġ�� �ʱ�ȭ
        transform.position = _movePos.position;

        // Dotween���� �̵� ����
        transform.DOMove(_backPos.position, duration)
                 .SetEase(Ease.InOutSine) // �ε巴�� �̵�
                 .SetLoops(-1, LoopType.Yoyo); // ���� �ݺ��ϸ� �Դٰ���
    }
}