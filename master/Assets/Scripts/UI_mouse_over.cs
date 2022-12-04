using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_mouse_over : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform Picture;
    [SerializeField]
    AudioManager.ButtonType buttonType;
    [SerializeField]
    string doggoName;

    public bool enable_zoom;

    int draw_index = 0;

    public void Awake()
    {
        if (!Picture)
        {
            Picture = this.gameObject.GetComponent<Transform>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // if (Picture != null)
        //     Picture.gameObject.SetActive(true);

        AudioManager.Instance.PlayHoverUI(buttonType, doggoName);

        if (enable_zoom)
        {
            draw_index = Picture.GetSiblingIndex();
            Picture.SetAsLastSibling();
            Picture.localScale = Vector3.one * 2.0f;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // if (Picture != null)
        //     Picture.gameObject.SetActive(false);

        if (enable_zoom)
        {
            Picture.SetSiblingIndex(draw_index);
            Picture.localScale = Vector3.one * 1.0f;
        }
    }
}
