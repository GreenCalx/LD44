﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leech : Monster
{
    public override string getMonsterName() { return Constants.monsters[2]; }

    public Leech()
    {
        base.spawn_chance = 0.7f;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.spawn_chance = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDamage(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplash, transform.position, transform.rotation);

        var Player = GameObject.Find("Player");
        var FS = Player.GetComponent<FameStacker>();
        FS.addFame(6);
    }

    public void OnKill(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplash, transform.position, transform.rotation);

        var Player = GameObject.Find("Player");
        var FS = Player.GetComponent<FameStacker>();
        FS.addFame(80);

        Destroy(gameObject);

    }
}