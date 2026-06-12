using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    private AudioSource myAudioSource;

    [Header("Pengaturan Scene")]
    public List<string> musicAllowedScenes;

    private bool isMusicOn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            myAudioSource = GetComponent<AudioSource>();

            // Ambil status music tersimpan
            isMusicOn = PlayerPrefs.GetInt("MusicStatus", 1) == 1;

            if (isMusicOn)
                myAudioSource.Play();
            else
                myAudioSource.Stop();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string currentSceneName = scene.name;

        if (musicAllowedScenes.Contains(currentSceneName) && isMusicOn)
        {
            PlayMusic();
        }
        else
        {
            myAudioSource.Stop();
        }
    }

    public void PlayMusic()
    {
        isMusicOn = true;

        PlayerPrefs.SetInt("MusicStatus", 1);
        PlayerPrefs.Save();

        if (!myAudioSource.isPlaying)
            myAudioSource.Play();
    }

    public void StopMusic()
    {
        isMusicOn = false;

        PlayerPrefs.SetInt("MusicStatus", 0);
        PlayerPrefs.Save();

        if (myAudioSource.isPlaying)
            myAudioSource.Stop();
    }
}