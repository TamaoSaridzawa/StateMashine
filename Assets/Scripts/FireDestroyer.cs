using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fire>(out Fire fire))
        {
            Destroy(fire.gameObject);
        }
    }
}
