using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IBreakable
{
    // Start is called before the first frame update
    private Animator boxAnimator;
    void Start()
    {
        boxAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        this.boxAnimator.SetBool("IsBroken", true);

    }

    public void LowerCondition(int damage)
    {
        return;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
        Break();
    }
}
