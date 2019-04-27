﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform _CameraTransform;
    private Vector3 _StartingPosition;
    private Quaternion _StartingRotation;
    public float Amount = 0.1f;

    public float Duration = 0.2f;
    private float _Count = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _CameraTransform = transform;
        _StartingPosition = transform.position;
        _StartingRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _Count = Duration;
        if (_Count > 0)
        {
            _CameraTransform.localPosition = _StartingPosition + Random.insideUnitSphere * Amount;
            _CameraTransform.Rotate(Vector3.forward, Random.Range(-20, 20) * Mathf.Deg2Rad);
            _Count -= Time.deltaTime;
        }
        else
        {
            _CameraTransform.localPosition = _StartingPosition;
            _CameraTransform.rotation = _StartingRotation;
        }
    }
}
