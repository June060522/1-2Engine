using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageShowScale : MonoBehaviour
{
    public BirdType birdType = BirdType.Small;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(birdType == BirdType.Small)
            {
                transform.localScale = new Vector3(0.3f,0.3f,0.3f);
                birdType = BirdType.Big;
            }
            else if(birdType == BirdType.Big)
            {
                transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                birdType = BirdType.Small;
            }
        }
    }
}
