using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FireDamage>(out FireDamage fire))
        {
            Destroy(fire.gameObject);
        }
    }
}
