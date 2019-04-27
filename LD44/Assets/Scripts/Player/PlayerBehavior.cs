using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(CharacterController2D))]
public class PlayerBehavior : MonoBehaviour
{
    private CharacterController2D _CC2D;
    private PlayerInputs _PI;
    private bool _IsFacingRight = true;

    public void OnDamage(Damager D, Damageable DA)
    {
        //ParticleSystem PS = GetComponentInChildren<ParticleSystem>();
        //PS.Play();
    }

    // Awake is called as Init
    private void Awake()
    {
        _PI = GetComponent<PlayerInputs>();
        _CC2D = GetComponent<CharacterController2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _CC2D.MoveHorizontal(Input.GetAxis(PlayerInputs._Key_horizontal));
        _CC2D.MoveVertical(Input.GetAxis(PlayerInputs._Key_vertical));
    }
}
