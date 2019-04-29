using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public override string getMonsterName() { return Constants.monsters[0]; }

    public KnockBack _KnockBack;

    public Slime()
    {
        base.spawn_chance = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.spawn_chance = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(_KnockBack)
        {
            if(_KnockBack.IsRunning)
            {
                _KnockBack.Apply(GetComponent<Rigidbody2D>());
            }
        }
           
    }

    public void OnKnockBack(KnockBack KB)
    {
        _KnockBack = Instantiate(KB);
        _KnockBack.Launch();
    }

    public void OnDamage(Damager iDamager, Damageable iDamageable)
    {
        
        Slime S = iDamager.GetComponent<Slime>();
        if (S)
        {
            if (S._KnockBack.IsRunning )
            {
                Instantiate(BloodSplashOnDmg, transform.position, transform.rotation);
                KnockBack KB = S._KnockBack;
                KB.Power *= 1 / iDamageable.Size;
                OnKnockBack(KB);
            }
        }
        else
        {
            Instantiate(BloodSplashOnDmg, transform.position, transform.rotation);
            KnockBack KB =iDamager._KnockBack;
            KB.Power *= 1 / iDamageable.Size;
            OnKnockBack(KB);
        }
    }

    public void OnDie(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplash, transform.position, transform.rotation);
        var Player = GameObject.Find("Player");
        var FS = Player.GetComponent<FameStacker>();
        FS.addFame(10);
        Destroy(gameObject);
    }

}
