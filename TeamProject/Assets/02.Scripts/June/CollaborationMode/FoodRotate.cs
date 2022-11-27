using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotate : MonoBehaviour
{
    int i = 0;
    void Start()
    {
        StartCoroutine(FoodMove());
    }

    IEnumerator FoodMove()
    {
        while(true)
        {
            i++;
            transform.rotation = Quaternion.Euler(0,0,i);
            yield return new WaitForSeconds(0.001f);       
        }
    }
}
