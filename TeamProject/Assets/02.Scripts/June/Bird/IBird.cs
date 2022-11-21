using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    right = 1,
    left = 2
}

public enum BirdType
{
    Big = 1,
    Small = 2
}

public interface IBird
{
    public void IMove(Vector2 dir, float speed);

    public void IFight(BirdType birdType);
}
