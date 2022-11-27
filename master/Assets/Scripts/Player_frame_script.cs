using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_frame_script : MonoBehaviour
{
    public GameObject[] Player_pictures;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Display_player_photo(Player_status_mgr.Instance.m_curr_player_age);
    }

    void Display_player_photo(Player_age age)
    {
        for (int i = 0; i < Player_pictures.Length; ++i)
        {
            Player_pictures[i].SetActive(false);
        }

        Player_pictures[(int)age].SetActive(true);
    }
}
