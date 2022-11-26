using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_mouse_over : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform Picture;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Picture.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
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
