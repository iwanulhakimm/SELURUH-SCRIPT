using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAksara : MonoBehaviour
{
    public GameObject panelNgalegena;
    public GameObject panelSwara;
    public GameObject panelAngka;
    public GameObject panelRarangken;

    public void ShowNgalegena()
    {
        panelNgalegena.SetActive(true);
        panelSwara.SetActive(false);
        panelAngka.SetActive(false);
        panelRarangken.SetActive(false);
    }

    public void ShowSwara()
    {
        panelNgalegena.SetActive(false);
        panelSwara.SetActive(true);
        panelAngka.SetActive(false);
        panelRarangken.SetActive(false);
    }

    public void ShowAngka()
    {
        panelNgalegena.SetActive(false);
        panelSwara.SetActive(false);
        panelAngka.SetActive(true);
        panelRarangken.SetActive(false);
    }

    public void ShowRarangken()
    {
        panelNgalegena.SetActive(false);
        panelSwara.SetActive(false);
        panelAngka.SetActive(false);
        panelRarangken.SetActive(true);
    }
}