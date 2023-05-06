using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public static bool SettingsMenuOn = false;

    public GameObject pauseMenuUI;

    public GameObject optionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused && pauseMenuUI != null || optionsMenuUI != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }  
        else
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        if(SettingsMenuOn)
        {
            SettingsOn();
            Cursor.visible = true;
        }
        else
        {
            SettingsOff();
            if(!SettingsMenuOn && GameIsPaused)
            {
                Cursor.visible = true;
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }       
    }

    public void SettingsOn()
    {
        optionsMenuUI.SetActive(true);
        SettingsMenuOn = true;
    }

    public void SettingsOff()
    {
        optionsMenuUI.SetActive(false);
        SettingsMenuOn = false;
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

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}

