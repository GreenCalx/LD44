using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nimbus : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        base.spawn_chance = 0.7f;
        base.monster_name = Constants.monsters[1];
    }

    // Update is called once per frame
    void Update()
    {
        base.spawn_chance = 0.7f;
        base.monster_name = Constants.monsters[1];
    }

    public void OnDamage(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplash, transform.position, transform.rotation);

        var Player = GameObject.Find("Player");
        var FS = Player.GetComponent<FameStacker>();
        FS.addFame(3);
    }

    public void OnKill(Damager iDamager, Damageable iDamageable)
    {
        Instantiate(BloodSplash, transform.position, transform.rotation);

        var Player = GameObject.Find("Player");
        var FS = Player.GetComponent<FameStacker>();
        FS.addFame(20);

        Destroy(gameObject);

    }
}
