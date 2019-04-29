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
}
