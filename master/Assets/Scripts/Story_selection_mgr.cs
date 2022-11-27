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

public enum Doggo
{
    Otis,
    Pablo,
    Rusty,
    Betsy,
    Nums
}

public class Story_selection_mgr : MonoSingleton<Story_selection_mgr>
{
    public TextAsset m_curr_text_asset;
    public Round_enum m_round_index;

    public UInt32 m_num_date_counter;

    // round availability
    bool[] m_round_available;

    private void Start()
    {
        m_round_available = new bool[(int)Doggo.Nums];
        Array.Fill(m_round_available, true);

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
        // disable the doggo until next round
        Doggo doggo_enum;
        Enum.TryParse(m_curr_text_asset.name, out doggo_enum);
        m_round_available[(int)doggo_enum] = false;

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

        // make all doggo available again for chat
        Array.Fill(m_round_available, true);
    }

    public bool Is_available_for_chat(Doggo doggo_enum)
    {
        return m_round_available[(int)doggo_enum];
    }

    public Doggo From_string(string name)
    {
        Doggo doggo_enum;
        Enum.TryParse(name, out doggo_enum);

        return doggo_enum;
    }
}
