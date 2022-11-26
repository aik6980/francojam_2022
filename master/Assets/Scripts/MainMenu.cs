using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		// Play the scene that are assigned in the Build Setttings "ctrl + shift + b" to open in order. 
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Settings()
	{
		SceneManager.LoadScene("Scene_UI_Settings");
	}

	public void BackButton()
	{
		SceneManager.LoadScene("Scene_UI_TitleScreen");
	}
}
