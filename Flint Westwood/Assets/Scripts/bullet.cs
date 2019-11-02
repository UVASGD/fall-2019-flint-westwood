using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public LayerMask collisionMask;
    public int maxBounces = 5;
    public int bounceCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
        {
            Vector2 reflectDir = Vector2.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0,0, rot);
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.die();
        }

        Wall wall = hitInfo.GetComponent<Wall>();
        if (wall != null)
        {
            bounceCount += 1;
        }

        if (bounceCount >= maxBounces)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.CompareTag("Wall"))
        {
            bounceCount += 1;
            Destroy(gameObject);
            if (bounceCount >= maxBounces)
            {
                Destroy(gameObject);
            }
        }
    }
}

