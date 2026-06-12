using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Header("Pengaturan Kotak")]
    public string hurufYangDiharapkan;
    public Image visualKotak; 

    private bool sudahTerisiBenar = false; 

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (sudahTerisiBenar == true)
            {
                return; 
            }

            DraggableItem itemYangDitarik = eventData.pointerDrag.GetComponent<DraggableItem>();

            if (itemYangDitarik != null)
            {
                PengaturSusunKata wasit = FindObjectOfType<PengaturSusunKata>();

                if (itemYangDitarik.idHuruf == hurufYangDiharapkan)
                {
                    itemYangDitarik.berhasilDitaruh = true;
                    visualKotak.sprite = itemYangDitarik.gambarAksara.sprite;
                    visualKotak.color = Color.green;
                    Invoke("KembalikanWarnaKotak", 0.5f); 
                    itemYangDitarik.gameObject.SetActive(false);
                    
                 
                    sudahTerisiBenar = true; 
                    
                    if (wasit != null) 
                    {
                        wasit.TambahSkorBenar();
                        wasit.MainkanSuaraBenar(); 
                    }
                }
                else
                {
                    itemYangDitarik.KembaliKePosisiAwal();
                    visualKotak.color = Color.red;
                    Invoke("KembalikanWarnaKotak", 1f); 
                    
                    if (wasit != null) 
                    {
                        wasit.TambahSkorSalah();
                        wasit.MainkanSuaraSalah(); 
                    }
                }
            }
        }
    }

    private void KembalikanWarnaKotak()
    {
        visualKotak.color = Color.white; 
    }
}
