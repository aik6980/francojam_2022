using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public enum FadeType
{
    FadeIn,
    FadeOut,
    FadeInOut,
    FadeOutIn
}

public class Fade_effect : MonoBehaviour
{
    [Tooltip("The UI element you want to fade")]
    [SerializeField]
    private MaskableGraphic element;

    [Tooltip("Fade type")]
    [SerializeField]
    private FadeType fadeType;

    [Tooltip("Fade time")]
    [SerializeField]
    public float start_delay = 1.0f;
    public float fade_time = 1.0f;
    public float idle_time = 1.0f;

    private Color color;

    void Start()
    {
        if (element == null)
        {
            element = this.gameObject.GetComponent<MaskableGraphic>();
        }

        color = element.color;
        switch (fadeType)
        {
        case FadeType.FadeIn:
            element.color = new Color(color.r, color.g, color.b, 0.0f);
            StartCoroutine(FadeIn());
            break;
        case FadeType.FadeOut:
            StartCoroutine(FadeOut());
            break;
        case FadeType.FadeInOut:
            element.color = new Color(color.r, color.g, color.b, 0.0f);
            StartCoroutine(FadeInOut());
            break;
        case FadeType.FadeOutIn:
            StartCoroutine(FadeOutIn());
            break;
        }
    }

    private IEnumerator FadeOut()
    {
        for (float a = fade_time; a >= 0; a -= Time.deltaTime)
        {
            var opacity = a / fade_time;

            element.color = new Color(color.r, color.g, color.b, opacity);
            yield return null;
        }
        element.color = new Color(color.r, color.g, color.b, 0.0f);
    }

    private IEnumerator FadeIn()
    {
        for (float a = 0; a <= fade_time; a += Time.deltaTime)
        {
            var opacity = a / fade_time;

            element.color = new Color(color.r, color.g, color.b, opacity);
            yield return null;
        }
    }

    private IEnumerator FadeInOut()
    {
        yield return new WaitForSeconds(start_delay);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(idle_time);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOutIn()
    {
        yield return new WaitForSeconds(start_delay);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(idle_time);
        StartCoroutine(FadeIn());
    }
}
