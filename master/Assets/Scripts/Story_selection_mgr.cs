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

public enum Day_txt_display
{
    day_0,
    day_1,
    day_2,
    day_3,
    ending_1,
    ending_2,
    ending_thanks,
}

public class Story_selection_mgr : MonoSingleton<Story_selection_mgr>
{
    public Dog_enum m_curr_dog;
    public Day_enum m_day_id;

    public UInt32 m_num_chat_counter;

    public List<string> m_day_title_texts;
    public List<string> m_day_subtitle_texts;

    public bool Debug_quick_round;

    // round availability
    bool[] m_available_dogs;
    bool[] m_selected_dogs;
    bool[] m_remaining_dogs;

    int m_chat_count = 4;

    // day text display
    Day_txt_display day_txt_display_enum;

    private void Start()
    {
        Reset_game();
    }

    public void Reset_game()
    {
        m_available_dogs = new bool[(int)Dog_enum.Nums];
        Array.Fill(m_available_dogs, true);

        m_selected_dogs = new bool[(int)Dog_enum.Nums];
        Array.Fill(m_selected_dogs, false);

        m_remaining_dogs = new bool[(int)Dog_enum.Nums];
        Array.Fill(m_remaining_dogs, true);

        Reset_round(Day_enum.day_1);
    }

    public void Enable_available_dogs()
    {
        for (int i = 0; i < (int)Dog_enum.Nums; ++i)
        {
            var game_obj = GameObject.Find(((Dog_enum)i).ToString());
            if (game_obj)
            {
                game_obj.SetActive(m_remaining_dogs[i]);
            }
        }
    }

    public void Enable_player_dogs()
    {
        for (int i = 0; i < (int)Dog_enum.Nums; ++i)
        {
            var game_obj = GameObject.Find(((Dog_enum)i).ToString());
            if (game_obj)
            {
                game_obj.SetActive(m_available_dogs[i]);
            }
        }
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
            day_txt_obj.GetComponent<TMP_Text>().text = Get_day_txt(day_txt_display_enum);
            loc_txt_obj.GetComponent<TMP_Text>().text = Get_loc_txt(day_txt_display_enum);
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
        m_available_dogs[(int)m_curr_dog] = false;
        m_selected_dogs[(int)m_curr_dog] = true;

        var need_transition = false;
        if (m_num_chat_counter <= 0)
        {
            m_day_id++;
            Reset_round(m_day_id);

            Array.Copy(m_available_dogs, m_remaining_dogs, m_selected_dogs.Length);

            need_transition = true;
        }

        if (m_day_id > Day_enum.day_3)
        {
            Story_selection_mgr.Instance.Scene_transition("Scene_transition", "Scene_ending", Day_txt_display.ending_1);

            Player_data_mgr.Instance.Add_dog(m_curr_dog);
            // enable only selected dogs from last round
            for (int i = 0; i < (int)Dog_enum.Nums; ++i)
            {
                m_available_dogs[i] = Player_data_mgr.Instance.Dogs[i];
            }
        }
        else
        {
            // update player data
            if (need_transition)
            {
                Story_selection_mgr.Instance.Scene_transition("Scene_transition", "Scene_selection",
                                                              (Day_txt_display)m_day_id);
            }
            else
            {
                SceneManager.LoadSceneAsync("Scene_selection");
            }
        }
    }

    public string Get_day_txt(Day_txt_display day_enum)
    {
        return m_day_title_texts[(int)day_enum];
    }

    public string Get_loc_txt(Day_txt_display day_enum)
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
            // make all doggo available again for chat
            Array.Fill(m_available_dogs, true);
            Array.Fill(m_selected_dogs, false);

            // mask out the dog that already adopted
            for (int i = 0; i < (int)Dog_enum.Nums; ++i)
            {
                if (Player_data_mgr.Instance.Dogs[i])
                {
                    m_available_dogs[i] = false;
                }
            }

            Array.Copy(m_available_dogs, m_remaining_dogs, m_selected_dogs.Length);
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

        // for fast forward testing
        if (Debug_quick_round)
        {
            m_num_chat_counter = 1;
        }

        if (d != Day_enum.day_1)
        {
            // enable only selected dogs from last round
            for (int i = 0; i < (int)Dog_enum.Nums; ++i)
            {
                m_available_dogs[i] = m_selected_dogs[i];
            }

            Array.Fill(m_selected_dogs, false);
        }
    }

    int get_max_chat_per_day(Day_enum d)
    {
        int max_chat = 0;
        switch (d)
        {
        case Day_enum.day_1:
            max_chat = 4;
            break;
        case Day_enum.day_2:
            max_chat = 2;
            break;
        case Day_enum.day_3:
            max_chat = 1;
            break;
        default:
            max_chat = 1;
            break;
        }

        // for fast forward testing
        if (Debug_quick_round)
        {
            max_chat = 1;
        }

        return max_chat;
    }
    public bool New_day_start()
    {
        return m_num_chat_counter == get_max_chat_per_day(m_day_id);
    }

    public bool Is_available_for_chat(Dog_enum doggo_enum)
    {
        return m_available_dogs[(int)doggo_enum];
    }

    public string Get_round_progression_string()
    {
        return "Day " + (int)(m_day_id) + "\nRemaining chat " + m_num_chat_counter;
    }
    public void Scene_transition(string scene_src, string scene_dst, Day_txt_display e)
    {
        StartCoroutine(Process_transition(scene_src, scene_dst, e));
    }
    IEnumerator Process_transition(string src, string dst, Day_txt_display e)
    {
        day_txt_display_enum = e;
        SceneManager.LoadSceneAsync(src);

        yield return new WaitForSeconds(5.0f);
        //
        SceneManager.LoadSceneAsync(dst);
    }
}
