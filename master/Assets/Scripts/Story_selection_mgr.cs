using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public UInt32 m_num_date_counter;

    private void Start()
    {
        Reset_round(Round_enum.round_1);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Finishing_round()
    {
        // Debug.Log(m_num_date_counter);
        m_num_date_counter--;

        if (m_num_date_counter <= 0)
        {
            m_round_index++;
            Reset_round(m_round_index);
        }

        if (m_round_index > Round_enum.round_3)
        {
            SceneManager.LoadScene("Scene_ending");
        }
        else
        {
            SceneManager.LoadScene("Scene_selection");
        }
    }

    private void Reset_round(Round_enum round)
    {
        m_round_index = round;
        switch (round)
        {
        case Round_enum.round_1:
            m_num_date_counter = 4;
            break;
        case Round_enum.round_2:
            m_num_date_counter = 2;
            break;
        case Round_enum.round_3:
            m_num_date_counter = 1;
            break;
        default:
            m_num_date_counter = 1;
            break;
        }
    }
}
