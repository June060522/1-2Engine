using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoss
{
    public void Move(Vector2 dir, float speed);

    public void Attack(GameObject target, float attackDelay);
}
