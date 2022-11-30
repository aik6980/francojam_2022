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
        Story_selection_mgr.Instance.Reset_round(Round_enum.round_1);
        Player_data_mgr.Instance.Increase_player_age();

        SceneManager.LoadScene("Scene_selection");
    }
}
