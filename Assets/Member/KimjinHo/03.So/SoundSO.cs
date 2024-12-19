using System.Reflection;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Sound/SoundSO")]
public class SoundSO : ScriptableObject
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;
    public string Name;

    public void SoundClip()
    {
        if (audioSource ==null)
            audioSource = GameObject.Find("SPX").GetComponent<AudioSource>();

        audioSource.clip = clip;
    }

    public void SoundPlay()
    {
        audioSource.Play();
    }
}