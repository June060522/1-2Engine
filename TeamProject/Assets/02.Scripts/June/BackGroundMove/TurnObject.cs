using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObject : MonoBehaviour
{
    [SerializeField] GameObject[] turnObject;
    public float rot;

    public static TurnObject Instance;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple GameManager is running!");
        }
        Instance = this;
    }
    public void Turning(float amount)
    {
        StartCoroutine(CoTurning(amount));
    }
    IEnumerator CoTurning(float amount)
    {
        rot = transform.rotation.x;
        while(rot != amount)
        {
            if(rot > amount)
                rot--;
            else if(rot < amount)
                rot++;
            
            foreach (GameObject obj in turnObject)
            {
                obj.transform.rotation = Quaternion.Euler(0,0,rot);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
