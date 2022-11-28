using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOrPause : MonoBehaviour
{
    private bool isPause = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
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
        Debug.Log("stop");

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));

        Time.timeScale = 1f;
        isPause = false;
        Debug.Log("play");
    }
}
