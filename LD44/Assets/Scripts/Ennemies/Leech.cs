using System.Collections;
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
}
