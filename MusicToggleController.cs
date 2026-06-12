using UnityEngine;
using UnityEngine.UI;

public class MusicToggleController : MonoBehaviour
{
    public Toggle musicToggle;

    void Start()
    {
        // Set toggle sesuai kondisi musik saat ini
        if (BackgroundMusic.Instance != null)
        {
            musicToggle.isOn = BackgroundMusic.Instance.GetComponent<AudioSource>().isPlaying;
        }

        // Tambahkan listener saat toggle berubah
        musicToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (BackgroundMusic.Instance == null) return;

        if (isOn)
        {
            BackgroundMusic.Instance.PlayMusic();
        }
        else
        {
            BackgroundMusic.Instance.StopMusic();
        }
    }
}