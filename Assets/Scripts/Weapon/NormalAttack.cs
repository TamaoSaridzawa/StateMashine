using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skill/NormalAttack", order = 51)]
public class NormalAttack : Skill
{
    //[SerializeField] private Transform _pointAtack;
    [SerializeField] private float _distanceAtack;
    [SerializeField] private LayerMask _enemyLayers;
    //private Transform _curentPos;

    public override void Action(Transform pos)
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(pos.position, _distanceAtack, _enemyLayers);
        //_curentPos = pos;

        if (hitEnemy == null)
        {
            return;
        }

        hitEnemy.GetComponent<Enemy>().TakeDamage(Damage);

    }

    //private void OnDrawGizmosSelected()
    //{
    //    if (_curentPos == null)
    //    {
    //        return;
    //    }
    ////    Gizmos.DrawSphere(_curentPos.position, _distanceAtack);
    //}
}
