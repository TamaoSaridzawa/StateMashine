using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackDamage : MonoBehaviour
{
    [SerializeField] private NormalAttack _normalAttack;
    [SerializeField] private float _distanceAtack;
    [SerializeField] private LayerMask _enemyLayers;

    public void CreateSkill(Transform pos)
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(pos.position, _distanceAtack, _enemyLayers);

        if (hitEnemy == null)
        {
            return;
        }

        hitEnemy.GetComponent<Enemy>().TakeDamage(_normalAttack.Power);
    }
}
