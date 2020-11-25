using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropped : MonoBehaviour, IDropHandler
{
    public RectTransform rectTransform;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
        if ((eventData.pointerDrag != null) && (eventData.pointerDrag.GetComponent<RectTransform>() == GetComponent<RectTransform>()))
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
        }
    }

}
