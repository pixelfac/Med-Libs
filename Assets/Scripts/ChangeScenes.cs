using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void ToScrollScene()
	{
		SceneManager.LoadScene("ScrollScene");
	}

	public void ToQuestionScene()
	{
		SceneManager.LoadScene("QuestionScene");
	}

	public void Quit()
	{
		Application.Quit();
	}

}
