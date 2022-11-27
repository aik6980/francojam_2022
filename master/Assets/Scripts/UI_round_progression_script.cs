using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_round_progression_script : MonoBehaviour
{
    public TMP_Text Text_display;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Text_display != null)
        {
            Text_display.text = Story_selection_mgr.Instance.Get_round_progression_string();
        }
    }
}
