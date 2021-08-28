using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool gamePause = false;
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
