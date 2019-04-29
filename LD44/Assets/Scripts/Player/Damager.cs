using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

// IMPORTANT (MTN5): Taken/inspired from Unity GameKit 2D

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour {
    [Serializable]
    public class DamageableEvent : UnityEvent<Damager, Damageable>
    { }

    public int Damage;
    public DamageableEvent OnDamageable;
    public KnockBack _KnockBack;

    public bool FilterPlayer = false;
    public bool AffectOnlyPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FilterPlayer)
        {
            var Cpmnt = collision.GetComponent<PlayerBehavior>();
            if( Cpmnt )
            {
                return;
            }
        }

        if (AffectOnlyPlayer)
        {
            var Cpmnt = collision.GetComponent<PlayerBehavior>();
            if (!Cpmnt)
            {
                return;
            }
        }

        var Damageable = collision.GetComponent<Damageable>();
        if (Damageable)
        {
            if (_KnockBack) _KnockBack.Direction = GetComponent<Rigidbody2D>().velocity;
            Damageable.TakeDamage(this);
            try
            {
                //OnDamageable.Invoke(this, Damageable);
            }
            catch (Exception e)
            {
                if (Constants.DEBUG_ENABLED)
                    print("Damager failed on OnTriggerEnter2D OnDamageable.Invoke");
            }
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
