using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Day_enum
{
    day_0,
    day_1,
    day_2,
    day_3,
}

public class Story_selection_mgr : MonoSingleton<Story_selection_mgr>
{
    public Dog_enum m_curr_dog;
    public Day_enum m_day_id;

    public UInt32 m_num_chat_counter;

    public List<string> m_day_title_texts;
    public List<string> m_day_subtitle_texts;

    // round availability
    bool[] m_round_available;

    int m_chat_count = 4;

    private void Start()
    {
        m_round_available = new bool[(int)Dog_enum.Nums];
        Array.Fill(m_round_available, true);

        Reset_round(Day_enum.day_1);
    }

    // Update is called once per frame
    void Update()
    {
        // update transition text
        // set the text
        var day_txt_obj = GameObject.Find("Day_txt");
        var loc_txt_obj = GameObject.Find("Loc_txt");
        if (day_txt_obj && loc_txt_obj)
        {
            day_txt_obj.GetComponent<TMP_Text>().text = Get_day_txt(m_day_id);
            loc_txt_obj.GetComponent<TMP_Text>().text = Get_loc_txt(m_day_id);
        }

        // update display
        var text_display_obj = GameObject.FindGameObjectWithTag("UI_Round_chat");
        if (text_display_obj != null)
        {
            var text_display_comp = text_display_obj.GetComponent<TMP_Text>();
            var text_display = "Day = " + m_day_id.ToString() + "\nRemaining chat = " + m_num_chat_counter;
            text_display_comp.text = text_display;

            for (int i = 0; i < m_chat_count; ++i)
            {
                var chat_icon = GameObject.Find("Chat_" + i);
                if (chat_icon)
                {
                    chat_icon.SetActive(i < m_num_chat_counter ? true : false);
                }
            }
        }
    }

    public void Finishing_round()
    {
        // Debug.Log(m_num_chat_counter);
        m_num_chat_counter--;
        // disable the doggo until next round
        m_round_available[(int)m_curr_dog] = false;

        var need_transition = false;
        if (m_num_chat_counter <= 0)
        {
            m_day_id++;
            Reset_round(m_day_id);
            need_transition = true;
        }

        if (m_day_id > Day_enum.day_3)
        {
            SceneManager.LoadScene("Scene_ending");
        }
        else
        {
            // update player data
            if (need_transition)
            {
                Story_selection_mgr.Instance.Scene_transition("Scene_transition", "Scene_selection");
            }
            else
            {
                SceneManager.LoadScene("Scene_selection");
            }
        }
    }

    public string Get_day_txt(Day_enum day_enum)
    {
        return m_day_title_texts[(int)day_enum];
    }

    public string Get_loc_txt(Day_enum day_enum)
    {
        return m_day_subtitle_texts[(int)day_enum];
    }

    public string Get_curr_round_string()
    {
        switch (m_day_id)
        {
        case Day_enum.day_1:
            return "round_1";
        case Day_enum.day_2:
            return "round_2";
        case Day_enum.day_3:
            return "round_3";
        default:
            return "round_1";
        }
    }

    public void Reset_round(Day_enum d)
    {
        m_day_id = d;
        switch (d)
        {
        case Day_enum.day_1:
            m_num_chat_counter = 4;
            break;
        case Day_enum.day_2:
            m_num_chat_counter = 2;
            break;
        case Day_enum.day_3:
            m_num_chat_counter = 1;
            break;
        default:
            m_num_chat_counter = 1;
            break;
        }

        // make all doggo available again for chat
        Array.Fill(m_round_available, true);
    }

    public bool Is_available_for_chat(Dog_enum doggo_enum)
    {
        return m_round_available[(int)doggo_enum];
    }

    public string Get_round_progression_string()
    {
        return "Day " + (int)(m_day_id) + "\nRemaining chat " + m_num_chat_counter;
    }
    public void Scene_transition(string scene_src, string scene_dst)
    {
        StartCoroutine(Process_transition(scene_src, scene_dst));
    }
    IEnumerator Process_transition(string src, string dst)
    {
        SceneManager.LoadScene(src);

        yield return new WaitForSeconds(5.0f);
        //
        SceneManager.LoadScene(dst);
    }
}
