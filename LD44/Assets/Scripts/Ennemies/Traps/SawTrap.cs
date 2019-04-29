using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : Trap
{
    public override string getTrapName() { return Constants.traps[0]; }
    public override float getSpawnChance() { return Constants.sawTrapSpawnChance; }

    public float rotations_rate;

    private float rotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 6.0f * rotations_rate * Time.deltaTime);
    }
}
