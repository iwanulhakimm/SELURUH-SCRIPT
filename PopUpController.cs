using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameObject panelNgalagena;
    public GameObject panelSwara;
    public GameObject panelAngka;
    public GameObject panelRarangken;

    // Fungsi bantu: matikan semua dulu
    void CloseAll()
    {
        panelNgalagena.SetActive(false);
        panelSwara.SetActive(false);
        panelAngka.SetActive(false);
        panelRarangken.SetActive(false);
    }

    public void OpenNgalagena()
    {
        CloseAll();
        panelNgalagena.SetActive(true);
    }

    public void OpenSwara()
    {
        CloseAll();
        panelSwara.SetActive(true);
    }

    public void OpenAngka()
    {
        CloseAll();
        panelAngka.SetActive(true);
    }

    public void OpenRarangken()
    {
        CloseAll();
        panelRarangken.SetActive(true);
    }
}
