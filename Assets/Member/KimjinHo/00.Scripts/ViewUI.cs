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
        if(StageManager.Instance.currentStage >= 6)
        {
            for (int i = 0; i < 6; i++)
            {
                Locks[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < StageManager.Instance.currentStage; i++)
            {
                Locks[i].gameObject.SetActive(false);
            }
        }
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
