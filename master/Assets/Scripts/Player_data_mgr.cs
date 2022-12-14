using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public enum Player_age
{
    low,
    mid,
    high,
}

public class Player_data_mgr : MonoSingleton<Player_data_mgr>
{
    public Player_age m_curr_player_age;

    // scores
    int m_likes_dogs = 5;
    int m_likes_cats = 5;
    int m_likes_kids = 5;
    int m_likes_walks = 5;
    int m_smart = 5;
    int m_active = 5;
    int m_playful = 5;
    bool m_has_dog = false;

    bool[] m_dogs;
    public bool[] Dogs
    {
        get => m_dogs;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset_game();

        debug_print();
    }

    public void Reset_game()
    {
        m_curr_player_age = Player_age.low;
        m_dogs = new bool[(int)Dog_enum.Nums];
        Array.Fill(m_dogs, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Increase_player_age()
    {
        m_curr_player_age++;
    }

    public void Add_dog(Dog_enum dog_enum)
    {
        m_dogs[(int)dog_enum] = true;
    }

    public void debug_print()
    {
        Debug.LogFormat("likes_dogs:{0}\n " + "likes_cats:{1}\n " + "likes_kids:{2}\n " + "likes_walks:{3}\n " +
                            "smart:{4}\n active:{5}\n playful:{6}\n has_dog:{7}\n",
                        m_likes_dogs, m_likes_cats, m_likes_kids, m_likes_walks, m_smart, m_active, m_playful,
                        m_has_dog);
    }

    public void read_from_ink(Story story)
    {
        m_likes_dogs = (int)story.variablesState["likes_dogs"];
        m_likes_cats = (int)story.variablesState["likes_cats"];
        m_likes_kids = (int)story.variablesState["likes_kids"];
        m_likes_walks = (int)story.variablesState["likes_walks"];
        m_smart = (int)story.variablesState["smart"];
        m_active = (int)story.variablesState["active"];
        m_playful = (int)story.variablesState["playful"];
        m_has_dog = (bool)story.variablesState["has_dog"];

        debug_print();
    }

    public void write_to_ink(Story story)
    {
        story.variablesState["likes_dogs"] = m_likes_dogs;
        story.variablesState["likes_cats"] = m_likes_cats;
        story.variablesState["likes_kids"] = m_likes_kids;
        story.variablesState["likes_walks"] = m_likes_walks;
        story.variablesState["smart"] = m_smart;
        story.variablesState["active"] = m_active;
        story.variablesState["playful"] = m_playful;
        story.variablesState["has_dog"] = m_has_dog;
    }

    public string get_emote_code_for_player_picture()
    {
        var emo_code = "";
        switch (m_curr_player_age)
        {
        case Player_age.low:
            emo_code = "";
            break;
        case Player_age.mid:
            emo_code = "Fe_1";
            break;
        case Player_age.high:
            emo_code = "Fe_2";
            break;
        }

        if (emo_code == "")
        {
            return "";
        }

        return "/emote:" + emo_code + "/";
    }

    public string get_adopted_dog_names()
    {
        List<string> name_ls = new List<string>();
        for (int i = 0; i < (int)Dog_enum.Nums; ++i)
        {
            if (m_dogs[i])
            {
                name_ls.Add(((Dog_enum)i).ToString());
            }
        }

        string name_str = "";
        for (int i = 0; i < name_ls.Count; ++i)
        {
            var prefix = "";
            if (i > 0)
            {
                if (i == name_ls.Count - 1)
                {
                    prefix = " and ";
                }
                else
                {
                    prefix = ", ";
                }
            }

            name_str += prefix + name_ls[i];
        }

        return name_str;
    }
}
