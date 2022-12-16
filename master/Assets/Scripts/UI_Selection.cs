using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Selection : MonoBehaviour
{
    public void Start()
    {
        Story_selection_mgr.Instance.Enable_available_dogs();
    }

    public void Play_story(string dog_name)
    {
        var dog_enum = Dog_stat_mgr.Instance.From_string(dog_name);

        if (Story_selection_mgr.Instance.Is_available_for_chat(dog_enum))
        {
            Story_selection_mgr.Instance.m_curr_dog = dog_enum;

            // Play the scene that are assigned in the Build Setttings "ctrl + shift + b" to open in order.
            SceneManager.LoadSceneAsync("DD_Ink_Test");
        }
        else
        {
            Debug.Log("not available for chat " + dog_enum.ToString());
        }
    }
}
