using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Run()
    {
        _animator.SetBool("Run", true);
    }

    public void Idle()
    {
       _animator.SetBool("Run", false);
        _animator.SetBool("Idle", true);
    }

    public void Attack()
    {
        _animator.SetTrigger("NormalAttack");
     
    }

    public void FireBall()
    {
        _animator.SetTrigger("Fire");
    }

    public void Shift()
    {
        _animator.SetTrigger("Shift");
    }

    public void Sword()
    {
        _animator.SetTrigger("Sword");
    }

    public void WoundDressing()
    {
        _animator.SetTrigger("Health");
    }
}
