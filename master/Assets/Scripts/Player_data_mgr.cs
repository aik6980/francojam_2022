using Ink.Runtime;
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

    // global persistent variable
    private static Player_data_mgr persistence_obj;

    // scores
    int m_likes_dogs = 5;
    int m_likes_cats = 5;
    int m_likes_kids = 5;
    int m_likes_walks = 5;
    int m_smart = 5;
    int m_active = 5;
    int m_playful = 5;
    bool m_has_dog = false;

    List<string> m_adopted_dogs;

    // Start is called before the first frame update
    void Start()
    {
        m_curr_player_age = Player_age.low;
        m_adopted_dogs = new List<string>();

        debug_print();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Increase_player_age()
    {
        m_curr_player_age++;
    }

    public void Add_dog(string name)
    {
        if (m_adopted_dogs.Contains(name) == false)
        {
            m_adopted_dogs.Add(name);
        }
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
}
