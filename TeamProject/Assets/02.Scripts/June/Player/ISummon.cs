using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummon 
{
    public void Summon(Team team,GameObject bird, Vector2 pos);
}