using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private List<SoundChannelSO> soundChannels;
    public Dictionary<SoundType, SoundChannelSO> _channels;

    private void Start()
    {
        Initialize();
        _channels.Add(SoundType.BGM, soundChannels[0]);

    }

    private void Initialize()
    {
        Debug.Log(soundChannels);

        if (soundChannels == null || soundChannels.Count == 0)
        {
            Debug.LogError("soundChannels is null or empty.");
            return;
        }

        _channels = new Dictionary<SoundType, SoundChannelSO>();

        foreach (SoundChannelSO soundChannel in soundChannels)
        {
            GameObject obj = new GameObject(soundChannel.name);
            obj.transform.parent = transform;

            soundChannel.clips = new Dictionary<string, AudioClip>();

            foreach (SoundSO sound in soundChannel.sounds)
                soundChannel.clips.Add(sound.key, sound.clip);

            soundChannel.players = new AudioSource[soundChannel.channel];
            for (int i = 0; i < soundChannel.players.Length; i++)
            {
                soundChannel.players[i] = obj.AddComponent<AudioSource>();
                soundChannel.players[i].outputAudioMixerGroup = soundChannel.mixerGroup;
                soundChannel.players[i].playOnAwake = soundChannel.playOnAwake;
                soundChannel.players[i].loop = soundChannel.loop;
                soundChannel.players[i].volume = soundChannel.volume;
                soundChannel.players[i].clip = soundChannel.sounds[0].clip;
            }

            _channels.Add(soundChannel.channelType, soundChannel);
        }
    }


    public void PlaySound(SoundType type, string value)
    {
        AudioSource[] audioSources = _channels[type].players;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
                continue;

            try
            {
                audioSources[i].clip = _channels[type].clips[value];
            }
            catch (KeyNotFoundException)
            {
                Debug.LogError("Can't found key. key Value :" + value);
                return;
            }
            audioSources[i].Play();
            break;
        }
    }

    public void StopSound(SoundType type, string value)
    {
        AudioSource[] audioSources = _channels[type].players;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (EqualityComparer<AudioClip>.Default.Equals(audioSources[i].clip, _channels[type].clips[value]))
                continue;

            audioSources[i].clip = null;
            audioSources[i].Stop();
            break;
        }
    }
}