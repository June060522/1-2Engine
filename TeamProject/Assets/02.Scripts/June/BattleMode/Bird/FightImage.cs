using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightImage : MonoBehaviour
{
    private float time = 0;
    private void OnEnable()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            PoolManager.Instance.Push(this.gameObject);
        }
    }
}
