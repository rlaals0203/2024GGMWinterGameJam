using DG.Tweening;
using UnityEngine;

public class ViewUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Locks;
    [SerializeField] private GameObject _gameObject;

    private bool _istrue = false;
    private void OnEnable()
    {
        StageChose.OnUnLock += OnUnlock;
    }
    public void OnUnlock()
    {
        int i = StageManager.Instance.currentStage;
        if (1 <= i)
            Locks[0].gameObject.SetActive(false);
        if (2 <= i)
            Locks[1].gameObject.SetActive(false);
        if (4 <= i)
            Locks[2].gameObject.SetActive(false);
        if (5 <= i)
            Locks[3].gameObject.SetActive(false);
        if (6 <= i)
            Locks[4].gameObject.SetActive(false);
        if (7 <= i)
            Locks[5].gameObject.SetActive(false);
    }
    public void Panel()
    {
        if (_istrue)
            Hide();
        else
            Show();
    }
    public void Show()
    {
        if (_gameObject == null || _gameObject.transform == null)
            return;

        _gameObject.SetActive(true);

        var seq = DOTween.Sequence();
        seq.Append(_gameObject.transform.DOScale(1.9f, 0.5f));
        seq.Append(_gameObject.transform.DOScale(1.8f, 0.1f));
        seq.Play();
        _istrue = true;
    }


    public void Hide()
    {
        if (_gameObject == null || _gameObject.transform == null)
            return;

        var seq = DOTween.Sequence();

        _gameObject.transform.localScale = Vector3.one * 0.2f;
        seq.Append(_gameObject.transform.DOScale(1.8f, 0.1f));
        seq.Append(_gameObject.transform.DOScale(0f, 0.5f));
        seq.Play().OnComplete(() =>
        {
            _gameObject?.SetActive(false);
        });
        _istrue = false;
    }
    private void OnDisable()
    {
        StageChose.OnUnLock -= OnUnlock;
    }
}
