using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  GENERIC INTERFACE FOR ALL MONSTERS IN GAME
/// </summary>
public class Monster : MonoBehaviour
{
    public float spawn_chance = 0.5f;

    public virtual string getMonsterName() { return ""; }

    public GameObject BloodSplash;
    public GameObject BloodSplashOnDmg;

    public KnockBack _KnockBack;

    public int FameOnDmg;
    public int FameOnDie;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnDamage(Damager iDamager, Damageable iDamageable)
    {
        Monster M = iDamager.GetComponent<Monster>();
        if (M)
        {
            if (M._KnockBack.IsRunning)
            {
                Instantiate(BloodSplashOnDmg, transform.position, transform.rotation);
                KnockBack KB = M._KnockBack;
                OnKnockBack(KB);
                _KnockBack.Power *= 1 / iDamageable.Size;

                iDamageable.CurrentHealth -= iDamager.Damage;
            }
        }
        else
        {
            Instantiate(BloodSplashOnDmg, transform.position, transform.rotation);
            KnockBack KB = iDamager._KnockBack;
            
            OnKnockBack(KB);
            _KnockBack.Power *= 1 / iDamageable.Size;
            var Player = GameObject.Find("Player");
            var FS = Player.GetComponent<FameStacker>();
            FS.addFame(FameOnDmg);

            iDamageable.CurrentHealth -= iDamager.Damage;

            iDamageable.CurrentInvincibilityTime = iDamageable.InvincibilityTime;
        }


    }

    public void OnKnockBack(KnockBack KB)
    {
        _KnockBack = Instantiate(KB);
        _KnockBack.Launch();
    }

    public void OnDie(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplash, transform.position, transform.rotation);
        var Player = GameObject.Find("Player");
        var FS = Player.GetComponent<FameStacker>();
        FS.addFame(FameOnDie);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (_KnockBack)
        {
            if (_KnockBack.IsRunning)
            {
                _KnockBack.Apply(GetComponent<Rigidbody2D>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
