using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayControllerScript : MonoBehaviour
{
    public static GameplayControllerScript instance;

	public static bool GameIsPaused = false;

	public GameObject PauseMenu;

	public TextMeshProUGUI enemyCounter;
    private int deathCounter;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (GameIsPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			if (GameIsPaused)
			{
				ResumeGame();
			}
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			if (GameIsPaused)
			{
				ExitGame();
			}
		}
		else if (Input.GetKeyDown(KeyCode.M))
		{
			if (GameIsPaused)
			{
				GoToMenu();
			}
		}

	}

	public void ResumeGame()
	{
		PauseMenu.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		Debug.Log("Game is resumed");
	}

	private void PauseGame()
	{
		PauseMenu.SetActive(true);
		// Freeze game
		Time.timeScale = 0f;
		GameIsPaused = true;
		Debug.Log("Game is paused");
	}

	public void GoToMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
	}

	public void ExitGame()
	{
		Debug.Log("Game has been exited");
		Application.Quit();
	}

	public void SetKillCounter()
    {
        deathCounter++;
        enemyCounter.text = "ENEMIES KILLED: " + deathCounter;
    }
}
