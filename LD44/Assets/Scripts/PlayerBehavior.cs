using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController2D))]
public class PlayerBehavior : MonoBehaviour
{
    private CharacterController2D _CC2D;
    private PlayerInput _PI;
    private bool _IsFacingRight = true;

    public void OnDamage(Damager D, Damageable DA)
    {
        //ParticleSystem PS = GetComponentInChildren<ParticleSystem>();
        //PS.Play();
    }

    // Awake is called as Init
    private void Awake()
    {
        _PI = GetComponent<PlayerInput>();
        _CC2D = GetComponent<CharacterController2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _CC2D.Move(PInput.Horizontal.Value, PInput.Jump.Down);
    }
}
