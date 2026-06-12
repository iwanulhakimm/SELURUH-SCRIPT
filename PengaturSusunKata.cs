using UnityEngine;
using UnityEngine.SceneManagement;

public class PengaturSusunKata : MonoBehaviour
{
    [Header("Pengaturan Level")]
    public GameObject[] daftarPanelSoal; 
    public int[] targetJawabanPerSoal;   

    [Header("Pengaturan Popup & Aturan")]
    public GameObject popupBenar;
    public GameObject popupSalah;
    public GameObject popupSelesai; 
    public int batasMaksimalSalah = 3; 

    [Header("Pengaturan Suara")]
    public AudioSource sumberSuara; 
    public AudioClip suaraKlik;     
    public AudioClip suaraBenar;    
    public AudioClip suaraSalah;    

    private int soalSaatIni = 0;
    private int jumlahBenarSaatIni = 0;
    private int jumlahSalahSaatIni = 0; 

    void Start()
    {
        
        if (popupBenar != null) popupBenar.SetActive(false);
        if (popupSalah != null) popupSalah.SetActive(false);
        if (popupSelesai != null) popupSelesai.SetActive(false);

        TampilkanSoal(0);
    }

    public void MainkanSuaraKlik()
    {
        if (sumberSuara != null && suaraKlik != null) sumberSuara.PlayOneShot(suaraKlik);
    }

    public void MainkanSuaraBenar()
    {
        if (sumberSuara != null && suaraBenar != null) sumberSuara.PlayOneShot(suaraBenar);
    }

    public void MainkanSuaraSalah()
    {
        if (sumberSuara != null && suaraSalah != null) sumberSuara.PlayOneShot(suaraSalah);
    }

    public void TambahSkorBenar()
    {
        jumlahBenarSaatIni++;
        if (jumlahBenarSaatIni >= targetJawabanPerSoal[soalSaatIni])
        {
            if (popupBenar != null) popupBenar.SetActive(true);
            Invoke("LanjutKeSoalBerikutnya", 2f); 
        }
    }

    public void TambahSkorSalah()
    {
        jumlahSalahSaatIni++;
        if (jumlahSalahSaatIni >= batasMaksimalSalah)
        {
            if (popupSalah != null) popupSalah.SetActive(true);
            Invoke("LanjutKeSoalBerikutnya", 2f); 
        }
    }

    private void LanjutKeSoalBerikutnya()
    {
        if (popupBenar != null) popupBenar.SetActive(false);
        if (popupSalah != null) popupSalah.SetActive(false);

        if (soalSaatIni < daftarPanelSoal.Length)
        {
            daftarPanelSoal[soalSaatIni].SetActive(false);
        }

        soalSaatIni++;
        jumlahBenarSaatIni = 0; 
        jumlahSalahSaatIni = 0; 

        if (soalSaatIni < daftarPanelSoal.Length)
        {
            TampilkanSoal(soalSaatIni);
        }
        else
        {
        
            if (popupSelesai != null) 
            {
                popupSelesai.SetActive(true); 
            }
        }
    }

    private void TampilkanSoal(int index)
    {
        foreach (GameObject panel in daftarPanelSoal)
        {
            panel.SetActive(false);
        }
        daftarPanelSoal[index].SetActive(true);
    }


    public void UlangiPermainan()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
