using System.Collections.Generic;

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
    }

    public void PlaySound(string name)
    {
        foreach (var dic in soundDic)
        {
            if (dic.Key.Equals(name))
            {
                dic.Key.SoundPlay();
            }
        }
    }
}
