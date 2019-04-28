using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public override string getMonsterName() { return Constants.monsters[0]; }

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

    public void OnDamage(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplashOnDmg, transform.position, transform.rotation);
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
