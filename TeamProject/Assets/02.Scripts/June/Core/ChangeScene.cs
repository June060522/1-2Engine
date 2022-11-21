using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Singleton<ChangeScene>
{
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
}
