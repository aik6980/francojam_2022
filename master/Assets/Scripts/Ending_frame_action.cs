using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_frame_action : MonoBehaviour
{
    public GameObject Ending_image;

    // Start is called before the first frame update
    void Start()
    {
        Story_selection_mgr.Instance.Enable_available_dogs();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Activate_ending()
    {
        Ending_image.SetActive(true);
    }
    public void Activate_newbegining()
    {
        Player_data_mgr.Instance.Increase_player_age();
        Story_selection_mgr.Instance.Scene_transition("Scene_transition", "Scene_ending_choice",
                                                      Day_txt_display.ending_2);
    }
}
