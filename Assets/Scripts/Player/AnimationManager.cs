using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsRun = "Run";
    private const string IsIdle = "Idle";
    private const string IsNormalAttack = "NormalAttack";
    private const string IsFire = "Fire";
    private const string IsShift = "Shift";
    private const string IsSword = "Sword";
    private const string IsHealth = "Health";

    public void Run()
    {
        _animator.SetBool(IsRun, true);
    }

    public void Idle()
    {
       _animator.SetBool(IsRun, false);
        _animator.SetBool(IsIdle, true);
    }

    public void Attack()
    {
        _animator.SetTrigger(IsNormalAttack);
    }

    public void FireBall()
    {
        _animator.SetTrigger(IsFire);
    }

    public void Shift()
    {
        _animator.SetTrigger(IsShift);
    }

    public void Sword()
    {
        _animator.SetTrigger(IsSword);
    }

    public void WoundDressing()
    {
        _animator.SetTrigger(IsHealth);
    }
}
