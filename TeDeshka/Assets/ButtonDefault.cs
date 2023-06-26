using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonDefault : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    public UnityEvent action;
    public float Scaling = 1.2f;
    
    private void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = transform.localScale / Scaling;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = transform.localScale * Scaling;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        action.Invoke();
    }
}
