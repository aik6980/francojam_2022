using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Round_enum
{
    round_1,
    round_2,
    round_3,
}

public class Story_selection_mgr : MonoSingleton<Story_selection_mgr>
{
    public TextAsset m_curr_text_asset;
    public Round_enum m_round_index;

    private void Start()
    {
        m_round_index = Round_enum.round_1;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
