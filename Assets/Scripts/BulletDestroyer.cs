using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FireDamage>(out FireDamage fire))
        {
            Destroy(fire.gameObject);
        }

        if (collision.TryGetComponent<SwordDamage>(out SwordDamage sword))
        {
            Destroy(sword.gameObject);
        }

        if (collision.TryGetComponent<AerialEnemyBullet>(out AerialEnemyBullet bullet))
        {
            bullet.gameObject.SetActive(false);
        }
    }
}
