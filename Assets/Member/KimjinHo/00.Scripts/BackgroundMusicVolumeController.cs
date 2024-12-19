using UnityEngine;

public class BackgroundMusicVolumeController : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    public SoundChannel bgSound; // 배경 음악 오디오 채널
    public AudioSource bgMusicSource; // 배경 음악 오디오 소스

    private string bgmName = "BGM";
    private float _volume;

    [SerializeField] private GameObject[] _cells;

    private void Start()
    {
        _volume = PlayerPrefs.GetFloat(bgmName, 1f); 

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
            _cells[i].SetActive(i < activeCells);

        bgMusicSource.volume = _volume;

        foreach (var sfxSource in bgSound.sounds)
        {
            sfxSource.volume = _volume;
            if (sfxSource.audioSource != null)
                sfxSource.audioSource.volume = _volume;
        }

        PlayerPrefs.SetFloat(bgmName, _volume);

        SetSound(soundManager._bgm);
        SoundPlay(bgSound.sounds[0].clip);
        bgSound.sounds[0].SoundPlay();

        DontDestroyOnLoad(this);
    }

    public void UpSound()
    {

       
        if (_volume >= 1f)
            return;

        _volume = Mathf.Clamp(_volume + 0.1f, 0f, 1f);

        bgMusicSource.volume = _volume;

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetActive(i <= activeCells);
        }



        PlayerPrefs.SetFloat(bgmName, _volume);
    }

    public void DownSound()
    {

        if (_volume <= 0f)
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i].SetActive(false);
            }
            return;
        }
            

        _volume = Mathf.Clamp(_volume - 0.1f, 0f, 1f);

        bgMusicSource.volume = _volume;

        int activeCells = Mathf.Clamp((int)(_volume * 10), 0, _cells.Length);
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].SetActive(i <= activeCells);
        }

        PlayerPrefs.SetFloat(bgmName, _volume);
    }

    public void SetSound(AudioSource audioSource)
    {
        foreach (var bgmSource in bgSound.sounds)
            bgmSource.audioSource = audioSource;
    }

    public void SoundPlay(AudioClip clip)
    {
        soundManager._bgm.clip = clip;
    }
}
