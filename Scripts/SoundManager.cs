using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    // [SerializeField] private AudioSource bridgeAudio;
    [SerializeField] private AudioClip bridgeClip;
    [SerializeField] private AudioClip starClip;
    [SerializeField] private AudioClip dirtClip;
    [SerializeField] private AudioClip roadClip;
    [SerializeField] private AudioClip teleportClip;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!audio.isPlaying)
        {
            audio.clip = null;
        }
    }

    public void bridgeSound()
    {
        audio.clip = bridgeClip;
        audio.Play();
    }

    public void starSound()
    {
        audio.clip = starClip;
        audio.Play();
    }

    public void dirtSound()
    {
        audio.clip = dirtClip;
        audio.Play();
    }

    public void roadSound()
    {
        audio.clip = roadClip;
        audio.Play();
    }

    public void teleportSound()
    {
        audio.clip = teleportClip;
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

}