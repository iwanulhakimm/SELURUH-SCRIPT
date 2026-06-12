using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// --- TAMBAHAN: Kita tambahkan IPointerDownHandler di baris ini ---
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [Header("Identitas Aksara")]
    public string idHuruf;

    [HideInInspector] public RectTransform rectTransform;
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public Vector2 posisiAwal;
    [HideInInspector] public bool berhasilDitaruh = false; 
    [HideInInspector] public Image gambarAksara; 

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        gambarAksara = GetComponent<Image>(); 
        
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    // --- FUNGSI BARU: Mendeteksi sentuhan super cepat ---
    public void OnPointerDown(PointerEventData eventData)
    {
        // Mainkan suara klik tepat saat jari/mouse menyentuh tombol (tanpa delay)
        PengaturSusunKata wasit = FindObjectOfType<PengaturSusunKata>();
        if (wasit != null) 
        {
            wasit.MainkanSuaraKlik();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posisiAwal = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f; 
        canvasGroup.blocksRaycasts = false; 
        berhasilDitaruh = false; 
        
        // (Pemanggilan suara klik dihapus dari sini karena sudah dipindah ke OnPointerDown)
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (berhasilDitaruh == false)
        {
            KembaliKePosisiAwal();
        }
    }

    public void KembaliKePosisiAwal()
    {
        rectTransform.anchoredPosition = posisiAwal;
    }
}