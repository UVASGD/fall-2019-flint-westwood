using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Breakable health = collision.GetComponent<Breakable>();

        if (health != null)
        {

            health.ReduceHealth(damage);

        }

    }

}
