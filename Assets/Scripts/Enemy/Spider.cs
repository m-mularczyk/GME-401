using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    private void Start()
    {
        Attack();
    }
    public override void Attack()
    {
        base.Attack();
        Debug.Log("Spider attack");
    }

    public override void Update()
    {
        //
    }
}
