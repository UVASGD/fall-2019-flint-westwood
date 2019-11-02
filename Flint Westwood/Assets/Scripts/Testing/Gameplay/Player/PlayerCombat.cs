using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private ScriptableWeapon currentWeapon;

    [SerializeField] private FloatVar playerHealth;

    private float _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        this._currentHealth = this.playerHealth.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleWeapons()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("I got hit!");
        }
    }
}
