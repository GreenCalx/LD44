using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    // Pairing < monstertype, spawn_chance(%)>
    public List<GameObject> spawnables;

    public Dictionary<Monster, float>         __monsterPool;
    public Dictionary<Monster, GameObject>  __monsterGameObjects;
    public float spawnRate;

    // Internals
    private List<Monster> __spawnArray;
    private float waitTime;
    private float timer;
   
    // Start is called before the first frame update
    void Start()
    {
        __monsterPool = new Dictionary<Monster, float>();
        __monsterGameObjects = new Dictionary<Monster, GameObject>();

        updateMonsterPoolandGO();
        generateSpawnArray();
        waitTime = (spawnRate > 0f) ?
             1 / spawnRate :
             1 ;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        { spawn(); timer = 0f; }
    }

    public void updateMonsterPoolandGO()
    {
        foreach (GameObject go in spawnables)
        {
            Monster m = go.GetComponent<Monster>();
            if (!!m)
            {
                __monsterPool.Add(m, m.spawn_chance);
                __monsterGameObjects.Add(m, go);
            }

        }
    }

    public void generateSpawnArray()
    {
        __spawnArray = new List<Monster>();
        foreach (Monster m in __monsterPool.Keys)
        {
            bool read_successfull = __monsterPool.TryGetValue(m, out float spawn_chance);
            if (!!read_successfull)
                for (int i = 0; i < spawn_chance; i++)
                    __spawnArray.Add(m);

        }
    }

    public void spawn()
    {
        int rand_res = Random.Range(0, __spawnArray.Count - 1);
        Monster monster_to_spawn = __spawnArray[rand_res];
        bool read_successfull = __monsterGameObjects.TryGetValue(monster_to_spawn, out GameObject entityToSpawn);
        if (!!read_successfull)
        {
            GameObject spawned = Instantiate(entityToSpawn);
            Vector3 spawn_offset = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
            spawned.transform.position = (transform.position += spawn_offset);
        }

    }

}
