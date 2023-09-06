using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject UiPause;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        UiPause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        paused = false;
    }
    public void Pause()
    {
        UiPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        paused = true;

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();

    }


}
