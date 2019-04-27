using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserPlayerBehavior : MonoBehaviour
{
    // Tweakables
    public float moveSpeed = 1f;


    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Transform playerTransform = GameObject.Find("Player").transform;
        target = playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        Transform parentTransform = GetComponentInParent<Transform>();
        parentTransform.LookAt(target);

        MoveScript moveScript = GetComponent<MoveScript>();
        moveScript.speed = new Vector2( moveSpeed, moveSpeed);

        moveScript.direction = parentTransform.forward;

    }
}
