using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Selection : MonoBehaviour
{
    public void PlayGame(TextAsset text_asset)
    {
        Story_selection_mgr.Instance.m_curr_text_asset = text_asset;

        // Play the scene that are assigned in the Build Setttings "ctrl + shift + b" to open in order.
        SceneManager.LoadScene("DD_Ink_Test");
    }
}
