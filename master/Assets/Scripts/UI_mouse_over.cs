using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_mouse_over : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform Picture;
    [SerializeField] AudioManager.ButtonType buttonType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Picture != null)
            Picture.gameObject.SetActive(true);

        AudioManager.Instance.PlayHoverUI(buttonType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Picture != null)
            Picture.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
