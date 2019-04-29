using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public string AudioOnFire;
    public string AudioOnDestruction;
    public float lifetime;
    public GameObject Explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Damage = collision.gameObject.GetComponent<Damager>();
        if(Damage)
        {
            if (Damage.AffectOnlyPlayer)
            {
                return;
            }
        }

        OnDamage();
    }

    void OnDamage()
    {
        var AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        AM_c.Play("BulletOnDestruction");

        Instantiate(Explosion, transform.position, transform.rotation);

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
