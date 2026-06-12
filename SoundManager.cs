using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;

    public AudioClip correctSound;
    public AudioClip wrongSound;

    void Awake()
    {
        instance = this;
    }

    public void PlayCorrect()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrong()
    {
        audioSource.PlayOneShot(wrongSound);
    }
}