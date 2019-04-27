using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserPlayerBehavior : MonoBehaviour
{
    // Tweakables
    //public float moveSpeed = 1f;
    public float SmoothSpeed = 0.3f;


    private Transform target;
    private Vector3 Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Transform playerTransform = GameObject.Find("Player").transform;
        target = playerTransform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 DesiredPosition;
        if (target)
        {
            DesiredPosition = target.position;
            Vector3 SmoothedPosition = Vector3.SmoothDamp(transform.position, DesiredPosition, ref Velocity, SmoothSpeed);
            transform.position = new Vector3(SmoothedPosition.x, SmoothedPosition.y, transform.position.z);
        }
    }
}
