using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackDamage : MonoBehaviour
{
    [SerializeField] private NormalAttack _normalAttack;
    [SerializeField] private float _distanceAtack;

    public void CreateSkill(Transform pos)
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(pos.position, _distanceAtack);
 
        if (hitEnemy == null)
        {
            return;
        }

        if (hitEnemy.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_normalAttack.Power);
        }
    }
}
