using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FameModifier : MonoBehaviour
{

    public int modifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FameStacker fstacker = collision.GetComponent<FameStacker>();
        if (!!fstacker)
            fstacker.addFame(modifier);

    }
}
