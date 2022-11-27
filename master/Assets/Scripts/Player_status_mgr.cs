using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_age
{
    low,
    mid,
    high,
}

public class Player_status_mgr : MonoSingleton<Player_status_mgr>
{
    public Player_age m_curr_player_age;

    // global persistent variable
    private static Player_status_mgr persistence_obj;

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
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Increase_player_age()
    {
        m_curr_player_age++;
    }
}
