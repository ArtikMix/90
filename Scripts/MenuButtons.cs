using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public int sc;
    public GameObject sure;
    public GameObject team;
    public GameObject info;

    private void Start()
    {
        FindObjectOfType<AudioManager>().PlayIt("KROVOSTOK");
    }

    public void NewGame()
    {
        sure.SetActive(true);
        info.SetActive(false);
    }

    public void Continue()
    {
        sc = PlayerPrefs.GetInt("lastScene");
        SceneManager.LoadScene(sc);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Yes()
    {
        SceneManager.LoadScene(1);
    }

    public void No()
    {
        sure.SetActive(false);
        info.SetActive(true);
    }

    public void Info()
    {
        team.SetActive(true);
        StartCoroutine(hideTeam());
    }

    IEnumerator hideTeam()
    {
        yield return new WaitForSeconds(7f);
        team.SetActive(false);
    }

    public void Temik()
    {
        Application.OpenURL("https://www.instagram.com/artikmix/");
    }

    public void Vlada()
    {
        Application.OpenURL("https://www.instagram.com/erroor666/");
    }

    public void Kirill()
    {
        Application.OpenURL("https://www.instagram.com/raffikireal/");
    }
}
