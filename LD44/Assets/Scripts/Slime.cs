using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public Slime()
    {
        base.spawn_chance = 1f;
        base.monster_name = Constants.monsters[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        base.spawn_chance = 1f;
        base.monster_name = Constants.monsters[0];
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
        FS.addFame(10);
        Destroy(gameObject);
    }

}
