using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject other;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector2 dir = Vector2.MoveTowards(this.transform.position, other.transform.position, step);
        this.transform.position = dir;
    }
}
