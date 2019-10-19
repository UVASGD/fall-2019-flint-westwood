using System;
using System.Collections;
using System.Collections.Generic;
using HealthDamage.Interfaces;
using UnityEngine;


public class Player : MonoBehaviour, IDamageable
{
    public enum PlayerState
    {
        WEAPON_HOLSTERED, WEAPON_DRAWN, INJURED, DEAD, WANTED, BOOSTED
    }
    
    [SerializeField] private int currentHealth;
    [SerializeField] private int baseHealth;
    [SerializeField] private ScriptableWeapon currentWeapon;
    private const int INITIAL_HEALTH = 5;
    public event Action<Player> playerDeathEvent;
    public event Action<Player> playerDamageEvent;
    public event Action<PlayerState> PlayerStateChangeEvent;
    public bool isFiring;
    private AudioSource _audioSource;
    [SerializeField] AudioClip[] clips = new AudioClip[3];
    private float cooldown = 0.5f;
    private float fireCooldown;
    [SerializeField] private GameObject bullet;
    
    

    private bool isHolstered;
    public int CurrentHealth
    {
        get => currentHealth;
        private set => currentHealth = value;
    }

    private void ChangeState(PlayerState newState)
    {
        PlayerStateChangeEvent?.Invoke(newState);
    }

    private void DebugChangeState()
    {
        if (Input.GetKeyDown(KeyCode.H) && isHolstered)
        {
            isHolstered = false; 
            Debug.Log("Weapon Drawn");
            ChangeState(PlayerState.WEAPON_DRAWN);
            _audioSource.clip = clips[0];
            _audioSource.Play();
        } else if (Input.GetKeyDown(KeyCode.H) && !isHolstered)
        {
            isHolstered = true;
            Debug.Log("Weapon Holstered");
            ChangeState(PlayerState.WEAPON_DRAWN);
        }
    }

    private void DebugFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fireCooldown <= Time.time)
        {
            fireCooldown = Time.time + cooldown;
            if (currentWeapon.ammoCount != 0)
            {
                StartCoroutine(FireGun());
                Debug.Log("Firing!");
            }
            else
            {
                Debug.Log("Out of ammo!");
                _audioSource.clip = clips[1];
                _audioSource.Play();
            }
        }
    }

    IEnumerator FireGun()
    {
        this.isFiring = true;
        this.GetComponent<Animator>().SetBool("isFiring", isFiring);
        FireBullet();
        _audioSource.clip = clips[2];
        _audioSource.Play();
        yield return new WaitForSeconds(.05f);
        this.isFiring = false;
        this.GetComponent<Animator>().SetBool("isFiring", isFiring);
    }

    private void FireBullet()
    {
        GameObject bulletClone = Instantiate(bullet, transform.GetChild(0).position, Quaternion.Euler(0f, 0f, -90f));
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(75f * Time.deltaTime, 0f, 0f);
    }
`
    
    public void TakeDamage(int health)
    {
        if (health < this.currentHealth)
        {
            this.currentHealth -= health;
        } else
        {
            Die();
        }
    }

    public void SetHealth(int health)
    {
        this.currentHealth = health;
    }

    private void Die()
    {
        if (this.currentHealth <= 0)
        {
            if (this.playerDeathEvent != null)
            {
                playerDeathEvent(this);
            }
        }
        Debug.Log("im dead rip");
    }

    // Start is called before the first frame update
    void Start()
    {
        this._audioSource = GetComponent<AudioSource>();
        this.currentWeapon.ammoCount = 6;
        this.currentHealth = baseHealth;
        this.isHolstered = true;
    }

    void Awake()
    {
        this.currentHealth = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DebugChangeState();
        DebugFiring();
    }
}
