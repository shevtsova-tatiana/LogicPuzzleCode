using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixer effectsMixer;

    public void SetVolume(float volume)
    {
        effectsMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("soundVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
}