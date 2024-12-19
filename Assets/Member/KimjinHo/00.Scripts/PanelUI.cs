using DG.Tweening;
using UnityEngine;

public class PanelUI : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    [SerializeField] private GameObject _tip;
    private static bool isInitialized = false; // static 변수로 상태 관리

    private bool _istrue = false;

    private void OnEnable()
    {
        if (!isInitialized) // 아직 초기화되지 않았을 경우에만 실행
        {
            DontDestroyOnLoad(GameObject);
            isInitialized = true; // 초기화 상태로 설정
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameObject.Find("TIPUI"))
                return;

            if (_istrue)
                Hide();
            else
                Show();
        }
    }

    public void Show()
    {
        if (_tip == null || _tip.transform == null)
            return;

        _tip.SetActive(true);

        var seq = DOTween.Sequence();
        seq.Append(_tip.transform.DOScale(1.9f, 0.5f));
        seq.Append(_tip.transform.DOScale(1.8f, 0.1f));
        seq.Play();
        _istrue = true;

        Cursor.visible = true;
    }


    public void Hide()
    {
        if (_tip == null || _tip.transform == null)
            return;

        var seq = DOTween.Sequence();

        _tip.transform.localScale = Vector3.one * 0.2f;
        seq.Append(_tip.transform.DOScale(1.8f, 0.1f));
        seq.Append(_tip.transform.DOScale(0f, 0.5f));
        seq.Play().OnComplete(() =>
        {
            _tip?.SetActive(false);
        });
        _istrue = false;

        Cursor.visible = false;
    }
}
