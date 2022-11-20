using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public GameObject Modpanel;
    public GameObject Settingpanel;
    public void ModChoose()
    {
        Modpanel.SetActive(true);
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        Settingpanel.SetActive(true);
    }
}
