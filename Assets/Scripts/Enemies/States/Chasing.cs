using System;
using UnityEngine;

[Serializable]
public class Chasing : BaseState
{
    public override void Enter()
    {
        base.Enter();


        Debug.Log("enemy is chasing");
    }
}
