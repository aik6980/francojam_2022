using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Selection : MonoBehaviour
{
    public void PlayGame()
    {
        // Play the scene that are assigned in the Build Setttings "ctrl + shift + b" to open in order.
        SceneManager.LoadScene("DD_Ink_Test");
    }
}
