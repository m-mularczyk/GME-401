using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnim;
    

    void Start()
    {
        _playerAnim = GetComponentInChildren<Animator>();
        
    }

    public void Move(float move)
    {
        _playerAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _playerAnim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _playerAnim.SetTrigger("Attack");
    }
}
