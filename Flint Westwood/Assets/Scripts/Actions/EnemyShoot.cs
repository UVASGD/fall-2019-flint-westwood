using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject bulletInstance = GameObject.Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(bulletInstance.transform.forward * 100);
        }
    }
}
