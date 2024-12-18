using UnityEngine;

[CreateAssetMenu(menuName = "SO/Sound/SoundSO")]
public class SoundSO : ScriptableObject
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;

    public void SoundClip()
    {
        audioSource.clip = clip;
    }

    public void SoundPlay()
    {
        Debug.Log(1);
        Debug.Log(audioSource);
        audioSource.Play();
    }
}