using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{

    private Vector3 _currentTarget;
    //private bool _switch;
    
    void Start()
    {
        
    }

    public override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (transform.position == _pointA.position)
        {
            //move to point b
            //_switch = false;
            _currentTarget = _pointB.position;

        }
        else if (transform.position == _pointB.position)
        {
            //move to point a
            //_switch = true;
            _currentTarget = _pointA.position;

        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, Time.deltaTime * speed);

        /*
        if (!_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, Time.deltaTime * speed);
        }
        */
    }
}
