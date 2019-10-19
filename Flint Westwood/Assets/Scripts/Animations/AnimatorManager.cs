using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private static readonly int WeaponHolstered = Animator.StringToHash("WEAPON_HOLSTERED");

    void Start()
    {
        this._animator = GetComponent<Animator>();
        this._animator.SetBool(WeaponHolstered, true);
        FindObjectOfType<Player>().PlayerStateChangeEvent += ChangeAnimationState;
        
    }

    public void ChangeAnimationState(Player.PlayerState newState)
    {
        _animator.SetBool(newState.ToString(), !_animator.GetBool(newState.ToString()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
