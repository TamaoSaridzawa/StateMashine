using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fire>(out Fire fire))
        {
            Debug.Log("SDSS");
            Destroy(fire.gameObject);
        }
    }
}
