using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoss
{
    public void IMove(Vector2 dir, float speed);

    public void IAttack(GameObject target, float attackDelay);

    public void IOnDamage(float damage);
}
