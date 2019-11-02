using UnityEngine;

public class Breakable : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private GameObject deathEffect;

    public bool ReduceHealth(float damage)
    {

        health -= damage;

        bool died = false;

        if (health <= 0)
        {

            died = true;

            Instantiate(deathEffect, transform.position, Quaternion.identity);

            return died;

        }

        return died;

    }

}
