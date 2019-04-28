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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
