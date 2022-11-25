using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageShowScale : MonoBehaviour
{
    public BirdType birdType = BirdType.Small;
    [SerializeField] private int selectIndex = 0;
    [SerializeField] private Team team = Team.right;
    [SerializeField] private LPlayer lPlayer;
    [SerializeField] private RPlayer rPlayer;
    private void Update()
    {
        if (team == Team.left)
        {
            if (Input.GetKeyDown(KeyCode.A) && lPlayer.SpawnIndex == selectIndex)
            {
                if (birdType == BirdType.Small)
                {
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    birdType = BirdType.Big;
                }
                else if (birdType == BirdType.Big)
                {
                    transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    birdType = BirdType.Small;
                }
            }
        }
        else if (team == Team.right)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && rPlayer.SpawnIndex == selectIndex)
            {
                if (birdType == BirdType.Small)
                {
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    birdType = BirdType.Big;
                }
                else if (birdType == BirdType.Big)
                {
                    transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    birdType = BirdType.Small;
                }

            }
        }
    }
}
