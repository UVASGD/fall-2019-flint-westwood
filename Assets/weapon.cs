using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public int maxBulletBounces = 5;
    public float maxTravelDistance = 200f;
    public LineRenderer lr;
    private bool hasBullet = true;

    void Update()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 exitPoint = new Vector2(firepoint.position.x, firepoint.position.y);
        Vector2 direction = target - exitPoint;
        direction.Normalize();

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);
        transform.rotation = rotation;

        if (Input.GetButtonDown("Fire2"))
        {
            Aim();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (hasBullet)
            {
                Shoot();
            }
        }
    }


    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);

        hasBullet = false;
    }

    void Aim()
    {
        DrawAimRay(transform.position, transform.forward , 5);
    }

    private void DrawAimRay(Vector3 position, Vector3 direction, int bounces)
    {
        if (bounces <= 0)
        {
            return;
        }

        Vector3 startPosition = position;

        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        lr.SetPosition(0, transform.position);


        if (Physics.Raycast(ray, out hit, maxTravelDistance))
        {
            /*
            direction = Vector3.Reflect(direction, hit.normal);
            */

            lr.SetPosition(1, hit.point);

            position = hit.point;
        
        }
        else
        {
            lr.SetPosition(1, transform.forward * 500);
            position += direction * maxTravelDistance;
        }

        DrawAimRay(position, direction, bounces - 1);
    }
}