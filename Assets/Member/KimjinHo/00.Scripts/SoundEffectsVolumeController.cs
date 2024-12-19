using UnityEngine;

public class SoundEffectsVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public SoundChannel sfxSound; // ȿ���� ����� �ҽ�

    private string sfxName = "SFX";
    private float _volume;

    [SerializeField] private GameObject[] _cells;

    private void Start()
    {
        _volume = PlayerPrefs.GetFloat(sfxName, 1f);

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
            _cells[i].SetActive(i < activeCells);

        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = _volume; // Sound ��ü�� ���� ����
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = _volume; // AudioSource ���� ����
        }

        PlayerPrefs.SetFloat(sfxName, _volume);
        SetSound(soundManager._sfx);
    }

    public void UpSound()
    {
        if (_volume >= 1f)
            return;

        _volume = Mathf.Clamp(_volume + 0.1f, 0f, 1f);

        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = _volume; // Sound ��ü�� ���� ����
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = _volume; // AudioSource ���� ����
        }

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetActive(i < activeCells);
        }

        PlayerPrefs.SetFloat(sfxName, _volume);
    }

    public void DownSound()
    {
        if (_volume <= 0f)
            return;

        _volume = Mathf.Clamp(_volume - 0.1f, 0f, 1f);

        foreach (var sfxSource in sfxSound.sounds)
        {
            sfxSource.volume = _volume; // Sound ��ü�� ���� ����
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = _volume; // AudioSource ���� ����
        }


        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetActive(i < activeCells);
        }

        PlayerPrefs.SetFloat(sfxName, _volume);
    }


    public void SetSound(AudioSource audioSource)
    {
        foreach (var bgmSource in sfxSound.sounds)
            bgmSource.audioSource = audioSource;
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._sfx.clip = clip;
        soundManager._sfx.Play();
    }
}