using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Selection : MonoBehaviour
{
    public void PlayGame(TextAsset text_asset)
    {
        Doggo doggo_enum = Story_selection_mgr.Instance.From_string(text_asset.name);
        if (Story_selection_mgr.Instance.Is_available_for_chat(doggo_enum))
        {
            Story_selection_mgr.Instance.m_curr_text_asset = text_asset;

            // Play the scene that are assigned in the Build Setttings "ctrl + shift + b" to open in order.
            SceneManager.LoadScene("DD_Ink_Test");
        }
        else
        {
            Debug.Log("not available for chat " + text_asset.name);
        }
    }
}
