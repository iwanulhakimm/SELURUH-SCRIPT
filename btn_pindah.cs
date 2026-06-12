using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_pindah : MonoBehaviour
{
    // Pindah ke scene berdasarkan nama scene
    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    // Keluar aplikasi
    public void KeluarAplikasi()
    {
        Debug.Log("Aplikasi Ditutup");
        Application.Quit();
    }
}