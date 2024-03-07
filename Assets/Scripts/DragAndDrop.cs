
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IDragHandler
{
    public Item actualItem;
    public RectTransform iconTransform;
    private void OnEnable()
    {
        actualItem = GetComponent<Item>();
        iconTransform = GetComponent<Item>().GetIconTransform();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        iconTransform.GetComponent<CanvasGroup>().alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        iconTransform.anchoredPosition += eventData.delta / 1;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        iconTransform.GetComponent<CanvasGroup>().alpha = 1f;
        iconTransform.anchoredPosition = Vector2.zero;
        Debug.Log("End Drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }
}
