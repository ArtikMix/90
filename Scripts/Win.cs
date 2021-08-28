using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public int kills = 0;
    public GameObject win;

    private void Update()
    {
        if (kills >= 50)
        {
            win.SetActive(true);
        }
    }

    public void TUCK()
    {
        SceneManager.LoadScene(0);
    }
}
