using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Weapons;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableWeapon : ScriptableObject
{
    public WeaponType weapon;
    public float damage;
    public int ammoCount;
    public bool canPickUp;
    public bool canReload;
    public bool isPurchasable;
    
}
