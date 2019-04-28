using UnityEngine;
using UnityEngine.Events;
using System;

// IMPORTANT (MTN5): Taken/inspired from Unity GameKit 2D

public class Damageable : MonoBehaviour {

    [Serializable]
    public class HealthEvent : UnityEvent<Damageable>
    { }

    [Serializable]
    public class DamageEvent : UnityEvent<Damager, Damageable>
    { }

    [Serializable]
    public class HealEvent : UnityEvent<int, Damageable>
    { }

    public DamageEvent OnDamage;
    public DamageEvent OnDie;
    public int StartingHealth;
    public int CurrentHealth;
    public bool InvincibleAfterDamage = true;
    public float InvincibilityTime = 2f;
    private float CurrentInvincibilityTime = 0f;
    public float Size;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CurrentInvincibilityTime -= Time.deltaTime;
        Mathf.Clamp(CurrentInvincibilityTime, -1, InvincibilityTime); // NOTE (MTN5) : Avoid underflow
	}

    private void OnEnable()
    {
        CurrentHealth = StartingHealth;
    }

    public void TakeDamage(Damager Damager)
    {
        if (CurrentInvincibilityTime <= 0)
        {
            CurrentHealth -= Damager.Damage;
            try
            {
                OnDamage.Invoke(Damager, this);
            } catch ( Exception e)
            {
                if (Constants.DEBUG_ENABLED)
                    print("Damageable failed on TakeDamage OnDamage.Invoke");
            }
            if (CurrentHealth <= 0)
            {
                OnDie.Invoke(Damager, this);
            }
            CurrentInvincibilityTime = InvincibilityTime;
        }
    }
}
