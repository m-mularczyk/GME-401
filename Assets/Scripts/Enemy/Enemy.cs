using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected Transform _pointA, _pointB;

    public virtual void Attack()
    {
        Debug.Log("Attacking by " + this.gameObject.name);
    }

    public abstract void Update();
}
