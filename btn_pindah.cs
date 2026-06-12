using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_pindah : MonoBehaviour
{

    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }


    public void KeluarAplikasi()
    {
        Debug.Log("Aplikasi Ditutup");
        Application.Quit();
    }
}
