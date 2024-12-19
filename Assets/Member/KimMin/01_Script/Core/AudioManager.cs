using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class AudioManager : MonoSingleton<AudioManager>
{
    public SoundChannel soundChanelSO;
    public Dictionary<SoundSO, string> soundDic = new Dictionary<SoundSO, string>();

    private void Awake()
    {
        foreach (var sound in soundChanelSO.sounds)
        { 
            soundDic.Add(sound,  sound.Name);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string name)
    {
        foreach (var pair in soundDic)
        {
            if (pair.Value == name)
            {
                pair.Key.SoundClip();
                pair.Key.SoundPlay(pair.Key.volume);
                return;
            }
        }
    }
}
