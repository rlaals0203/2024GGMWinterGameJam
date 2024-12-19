using UnityEngine;

public class PanelUI : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    private static bool isInitialized = false; // static ������ ���� ����

    private void OnEnable()
    {
        if (!isInitialized) // ���� �ʱ�ȭ���� �ʾ��� ��쿡�� ����
        {
            DontDestroyOnLoad(GameObject);
            isInitialized = true; // �ʱ�ȭ ���·� ����
        }
    }
}
