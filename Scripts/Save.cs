using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject D;
    public Text dialog;
    private string[] first = { "Как же я сегодня №!#", "Скорее бы добраться до дома...", "Это ещё что такое?", "@!#$, а как же всё сегодня $^!# шло!", "%:!@ вам, твари!", "%:!@ вам, твари!" };
    private int count = 0;
    private int once = 0;
    public bool end = false;

    private void Start()
    {
        dialog.text = first[0];
        FindObjectOfType<AudioManager>().PlayIt("Молодой");
    }

    private void Update()
    {
        dialog.text = first[count];
        if (count >= 5)
        {
            D.SetActive(false);
            end = true;
            FindObjectOfType<AudioManager>().StopIt("авария");
        }
        if(count==3 && once == 0)
        {
            once = 1;
            FindObjectOfType<AudioManager>().StopIt("Молодой");
            FindObjectOfType<AudioManager>().PlayIt("авария");
        }
    }
    public void SaveButton()
    {
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Tick()
    {
        count++;
    }

    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void vpizdu()
    {
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}
