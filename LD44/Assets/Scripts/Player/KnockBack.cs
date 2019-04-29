using UnityEngine;
using System.Collections;

public class KnockBack : MonoBehaviour
{
    public float Duration;
    public float Power;
    public Vector2 Direction;

    private float _CurrentTime = 0;
    public bool IsRunning = false;

    void Start()
    {
        _CurrentTime = Duration;
    }

    private void Update()
    {
        _CurrentTime -= Time.deltaTime;
        if(_CurrentTime <= 0)
        {
            IsRunning = false;
        }
    }

    private void FixedUpdate()
    {
        _CurrentTime -= Time.deltaTime;
        if (_CurrentTime <= 0)
        {
            IsRunning = false;
        }
    }

    public void Launch()
    {
        _CurrentTime = Duration;
        IsRunning = true;
        Destroy(gameObject, Duration);
    }

    public void Apply( Rigidbody2D RB )
    {
        if (IsRunning)
        {
            RB.velocity = Direction * Power;
        }
    }
}
