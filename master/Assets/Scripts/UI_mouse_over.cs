using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_mouse_over : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform Picture;
    [SerializeField] AudioManager.ButtonType buttonType;
    [SerializeField] string doggoName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Picture != null)
            Picture.gameObject.SetActive(true);

        AudioManager.Instance.PlayHoverUI(buttonType, doggoName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Picture != null)
            Picture.gameObject.SetActive(false);
    }
}
