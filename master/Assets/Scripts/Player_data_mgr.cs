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
    uint m_likes_dogs = 5;
    uint m_likes_cats = 5;
    uint m_likes_kids = 5;
    uint m_likes_walks = 5;
    uint m_smart = 5;
    uint m_active = 5;
    uint m_playful = 5;
    bool m_has_dog = false;

    List<string> m_adopted_dogs;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (persistence_obj == null)
        {
            persistence_obj = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_curr_player_age = Player_age.low;
        m_adopted_dogs = new List<string>();
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
        uint likes_dogs = 5;
        uint likes_cats = 5;
        uint likes_kids = 5;
        uint likes_walks = 5;
        uint smart = 5;
        uint active = 5;
        uint playful = 5;
        bool has_dog = false;

        Debug.LogFormat("", m_likes_dogs, m_likes_cats, m_likes_kids, m_likes_walks, m_smart, m_active, m_playful,
                        m_has_dog);
    }
}
