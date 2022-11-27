using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Button_DownUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] AudioManager.ButtonType buttonType;
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.Instance.PlayClickDownUI(buttonType);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.Instance.PlayClickUpUI(buttonType);
    }
}
