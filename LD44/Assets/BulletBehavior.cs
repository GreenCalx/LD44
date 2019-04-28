using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public string AudioOnFire;
    public string AudioOnDestruction;
    public float lifetime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Explode

        var AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        AM_c.Play("BulletOnDestruction");

        Object.Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        AM_c.Play("BulletOnDestruction");

        Object.Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        var AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        AM_c.Play("BulletOnFire");
    }

    void Awake()
    {
        Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
