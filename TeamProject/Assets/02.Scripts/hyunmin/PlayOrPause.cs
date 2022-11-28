using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOrPause : MonoBehaviour
{
    private bool isPause = false;
    public GameObject Explain;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Explain.SetActive(true);
            if(!isPause)
            {
                StartCoroutine(Click());
            }
        }
    }

    private IEnumerator Click()
    {
        Time.timeScale = 0f;
        isPause = true;

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape) || isPause == false);

        
        Time.timeScale = 1f;
        Explain.SetActive(false);
        isPause = false;
    }

    public void Xbutton()
    {
        Time.timeScale = 1f;
        Explain.SetActive(false);
        isPause = false;
    }

    public void Lobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }
}
