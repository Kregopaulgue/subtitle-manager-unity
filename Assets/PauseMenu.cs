using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public InputField inputField;

    private SubtitleGuiManager guiManager;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
        guiManager = FindObjectOfType<SubtitleGuiManager>();

    }

    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void changeFontSize()
    {
        int newFontSize = Int32.Parse(inputField.text);
        guiManager.SetFontSize(newFontSize);
    }

    public void turnSubtitlesOnOrOff()
    {
        guiManager.TurnSubtitles();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
