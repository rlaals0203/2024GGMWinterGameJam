using UnityEngine;

public class PanelUI : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    private static bool isInitialized = false;

    private void OnEnable()
    {
        if (!isInitialized)
        {
            DontDestroyOnLoad(GameObject);
            isInitialized = true;
        }
    }
}
