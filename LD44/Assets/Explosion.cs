using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Duration;
    private float CurrentTime;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        if(CurrentTime<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
