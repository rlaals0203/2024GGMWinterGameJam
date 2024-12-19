using UnityEngine;
using UnityEngine.Rendering;

public class VolumeController : MonoBehaviour
{

    private string AllName = "All";
    private float _volume;

    [SerializeField] private GameObject[] _cells;

    private void Start()
    {
        _volume = PlayerPrefs.GetFloat(AllName, 1f);

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
            _cells[i].SetActive(i < activeCells);

        PlayerPrefs.SetFloat(AllName, _volume);

        SetVolume(_volume);
    }

    // 전체 음량 조절 함수
    private void SetVolume(float volume)
    {
        AudioListener.volume = volume; // AudioListener의 volume 값을 변경
        PlayerPrefs.SetFloat(AllName, volume);
    }
    public void UpSound()
    {
        

        if (_volume >= 1f)
            return;

        _volume = Mathf.Clamp(_volume + 0.1f, 0f, 1f);

        AudioListener.volume = _volume;

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetActive(i < activeCells);
        }

        PlayerPrefs.SetFloat(AllName, _volume);
    }

    public void DownSound()
    {
      

        if (_volume <= 0f)
            return;

        _volume = Mathf.Clamp(_volume - 0.1f, 0f, 1f);

        AudioListener.volume = _volume;

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetActive(i < activeCells);
        }

        PlayerPrefs.SetFloat(AllName, _volume);
    }
}