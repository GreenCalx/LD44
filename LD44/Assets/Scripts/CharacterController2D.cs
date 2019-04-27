using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float _MaxSpeed = 10f;
    private Rigidbody2D _RB;

    // Awake is called as Init
    private void Awake()
    {
        _RB = GetComponent<Rigidbody2D>();
    }

    public void Move(float HorizontalMovement)
    {
        _RB.velocity = new Vector2(HorizontalMovement * _MaxSpeed, _RB.velocity.y);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
