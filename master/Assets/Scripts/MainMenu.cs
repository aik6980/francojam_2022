using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        // reset game
        Player_data_mgr.Instance.Reset_game();
        Dog_stat_mgr.Instance.Reset_game();
        Story_selection_mgr.Instance.Reset_game();
    }

    public void PlayGame()
    {
        // Play the scene that are assigned in the Build Setttings "ctrl + shift + b" to open in order.
        SceneManager.LoadSceneAsync("Scene_player_profile");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync("Scene_UI_Settings");
    }

    public void BackButton()
    {
        SceneManager.LoadSceneAsync("Scene_UI_TitleScreen");
    }
}
