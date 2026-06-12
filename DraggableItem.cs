using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public void OnPointerDown(PointerEventData eventData)
    {
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
