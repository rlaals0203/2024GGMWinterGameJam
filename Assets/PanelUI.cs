using UnityEngine;

public class PanelUI : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    private static bool isInitialized = false; // static 변수로 상태 관리

    private void OnEnable()
    {
        if (!isInitialized) // 아직 초기화되지 않았을 경우에만 실행
        {
            DontDestroyOnLoad(GameObject);
            isInitialized = true; // 초기화 상태로 설정
        }
    }
}
