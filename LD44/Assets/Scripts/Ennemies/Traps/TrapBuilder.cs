using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBuilder : MonoBehaviour
{
    // MAND
    public List<GameObject> trapLocations;
    public List<GameObject> poolOfUnlockableTraps;
    public bool able_to_spawn;

    //INTERNAL
    private List<GameObject> __spawnableTraps;
    private List<GameObject> __spawnedTraps;
    private float waitTime = Constants.intervalBetweenTrapSpawn;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        __spawnableTraps = new List<GameObject>();
        __spawnedTraps = new List<GameObject>();
        refreshAbleToSpawn();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        { spawn(); timer = 0f; }
    }

    public void refreshAbleToSpawn()
    {
        able_to_spawn =
            (trapLocations != null) &&
            (trapLocations.Count > 0) &&
            (poolOfUnlockableTraps != null) &&
            (poolOfUnlockableTraps.Count > 0)
            ;
        if (Constants.DEBUG_ENABLED)
            print(" TRAP BUILDER ABLE TO SPAWN ? " + able_to_spawn);
    }

    public void updateSpawnableArray()
    {
        foreach (string item in Constants.items)
        {
            bool read = Constants.unlocked_items.TryGetValue(item, out string save_slot);
            if (!!read)
            {
                int unlock_status = PlayerPrefs.GetInt(save_slot, 0);
                if (unlock_status == 1)
                {
                    // add monster to spawnables
                    foreach (GameObject go in poolOfUnlockableTraps)
                    {
                        Trap trap = go.GetComponent<Trap>();
                        if (!!trap)
                        {
                            if (trap.getTrapName() == item)
                            {
                                __spawnableTraps.Add(go);
                            }
                        }
                    }//!for
                }
            }
        }//!for
    }

    public void spawn()
    {
        if (able_to_spawn)
        {
            // GET A RANDOM TRAP
            updateSpawnableArray();
            int n_traps = __spawnableTraps.Count;
            if (n_traps > 0)
            {
                int rand_trap_index = Random.Range(0, n_traps - 1);

                // CREATE
                GameObject newborn = Instantiate(__spawnableTraps[rand_trap_index]);
                if (__spawnedTraps.Count >= Constants.maxTrapSpawn)
                {
                    GameObject toDelete = __spawnedTraps[0];
                    __spawnedTraps.RemoveAt(0);
                    Destroy(toDelete);

                    __spawnedTraps.Add(newborn);
                }
                else { __spawnedTraps.Add(newborn); }

                // LOCATION
                Transform location;
                int n_spawners = trapLocations.Count;
                int rand_index = Random.Range(0, (n_spawners - 1));
                GameObject loc_ref = trapLocations[rand_index];
                location = loc_ref.GetComponent<Transform>();

                newborn.transform.position = location.position;
            }//!n_traps > 0
        }//! able to spawn
    }
}
