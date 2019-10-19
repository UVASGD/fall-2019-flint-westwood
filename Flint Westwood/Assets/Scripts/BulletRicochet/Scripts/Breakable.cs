using UnityEngine;

public class Breakable : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private GameObject deathEffect;

    public void ReduceHealth(float damage)
    {

        health -= damage;

        if (health <= 0)
        {

            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);

        }

    }

}
