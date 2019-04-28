using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform PlayerTransform = GameObject.Find("Player").transform;
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, transform.position.z);
    }
}
