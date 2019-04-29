using System.Collections;
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
    private bool _IsShaking = false;
    // Start is called before the first frame update
    void Start()
    {
        _CameraTransform = transform;
        _StartingPosition = transform.position;
        _StartingRotation = transform.rotation;
    }

    void Shake()
    {
        _StartingPosition = transform.position;
        _StartingRotation = transform.rotation;
        _IsShaking = true;
        _Count = Duration;
    }

    public void OnShake()
    {
        if (Input.GetButtonDown(PlayerInputs._Key_A)) Shake();
        if (_Count > 0)
        {
            var newPos = GameObject.Find("Player").transform.position + Random.insideUnitSphere * Amount;
            _CameraTransform.position = new Vector3(newPos.x, newPos.y, _CameraTransform.position.z);
            //_CameraTransform.Rotate(Vector3.forward, Random.Range(-20, 20) * Mathf.Deg2Rad);
            _Count -= Time.deltaTime;
        }
    }

    public bool IsShaking()
    {
        return _IsShaking;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
