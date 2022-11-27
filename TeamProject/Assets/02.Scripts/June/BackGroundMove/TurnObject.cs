using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObject : MonoBehaviour
{
    [SerializeField] GameObject[] turnObject;
    public void Turning(float amount)
    {
        StartCoroutine(CoTurning(amount));
    }
    IEnumerator CoTurning(float amount)
    {
        float i = transform.rotation.x;
        while(i != amount)
        {
            if(i > amount)
                i--;
            else if(i < amount)
                i++;
            
            foreach (GameObject obj in turnObject)
            {
                obj.transform.rotation = Quaternion.Euler(0,0,i);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
