using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int indexNormalAttack = 0;
    private int indexSwordAttack = 1;
    private int indexFireAttack = 2;

    public void Run()
    {
        _animator.SetBool("LaunchFireball", false);
        _animator.SetBool("Run", true);
        _animator.SetBool("Idle", false);
        _animator.SetBool("Attack", false);
    }

    public void Idle()
    {
        _animator.SetBool("LaunchFireball", false);
        _animator.SetBool("Run", false);
        _animator.SetBool("Idle", true);
        _animator.SetBool("Attack", false);
    }

    public void Attack(int numberAttack)
    {
        if (numberAttack == indexSwordAttack || numberAttack == indexNormalAttack)
        {
            _animator.SetBool("Attack", true);
            _animator.SetBool("LaunchFireball", false);
        }
        if (numberAttack == indexFireAttack)
        {
            _animator.SetBool("Attack", false);
            _animator.SetBool("LaunchFireball", true);
        }
        _animator.SetBool("Run", false);
        _animator.SetBool("Idle", false);
       
    }
}
