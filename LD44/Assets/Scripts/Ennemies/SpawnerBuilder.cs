using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBuilder : MonoBehaviour
{
    // MAND
    public List<GameObject> spawnerLocations;
    public List<GameObject> poolOfUnlockableMonsters;
    public GameObject defaultMonsterToSpawn;
    public GameObject monsterSpawnerGO;
    public bool able_to_spawn;

    //INTERNAL
    private List<GameObject> spawnedMonsterSpawners;
    private float waitTime = Constants.intervalBetweenMonsterSpawnersSpawn;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spawnedMonsterSpawners = new List<GameObject>();
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
            (spawnerLocations != null) &&
            (spawnerLocations.Count > 0) &&
            (poolOfUnlockableMonsters != null) &&
            (poolOfUnlockableMonsters.Count > 0) &&
            (monsterSpawnerGO != null) &&
            (defaultMonsterToSpawn != null)
            ;
        if (Constants.DEBUG_ENABLED)
            print(" SPAWNER BUILDER ABLE TO SPAWN ? " + able_to_spawn);
    }

    public void spawn()
    {
        if (able_to_spawn)
        {
            // CREATE
            GameObject newborn = Instantiate(monsterSpawnerGO);
            if (spawnedMonsterSpawners.Count > Constants.maxMonsterSpawnersSpawn)
            {
                GameObject toDelete = spawnedMonsterSpawners[0];
                spawnedMonsterSpawners.RemoveAt(0);
                Destroy(toDelete);

                spawnedMonsterSpawners.Add(newborn);
            }
            else
            {
                spawnedMonsterSpawners.Add(newborn);
            }

            // UPDATE NEZ BORN
            // Location
            Transform location;
            int n_spawners = spawnerLocations.Count;
            int rand_index = Random.Range(0, (n_spawners - 1));
            GameObject loc_ref = spawnerLocations[rand_index];
            location = loc_ref.GetComponent<Transform>();

            newborn.transform.position = location.position;

            // Spawnable monsters
            MonsterSpawner monsterSpawner = newborn.GetComponent<MonsterSpawner>();
            if (!!monsterSpawner)
            {
                // Add Default monster
                monsterSpawner.spawnables = new List<GameObject>();
                monsterSpawner.spawnables.Add(defaultMonsterToSpawn);

                // Add Unlockable monsters
                foreach (string item in Constants.items)
                {
                    bool read = Constants.unlocked_items.TryGetValue(item, out string save_slot);
                    if (!!read)
                    {
                        int unlock_status = PlayerPrefs.GetInt(save_slot, 0);
                        if (unlock_status == 1)
                        {
                            // add monster to spawnables
                            foreach (GameObject go in poolOfUnlockableMonsters)
                            {
                                Monster monster = go.GetComponent<Monster>();
                                if (!!monster)
                                {
                                    if (monster.getMonsterName() == item)
                                    {

                                        monsterSpawner.spawnables.Add(go);
                                    }
                                }
                            }//!for
                        }
                    }
                }//!for
                //monsterSpawner.updateMonsterPoolandGO();
                //monsterSpawner.generateSpawnArray();
            }

        }//! able to spawn
    }
}
