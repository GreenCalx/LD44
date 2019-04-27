using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera _Camera;
    private Vector2 FireVector;
    public GameObject Bullet;
    private Transform _Parent;
    private Transform _StartingPosition;
    public GameObject FireExit;
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _Camera = FindObjectOfType<Camera>();
        _Parent = this.transform.parent.transform;
        _StartingPosition = this.transform;
    }

    public void OnFire()
    {
        var b = Instantiate(Bullet, FireExit.transform.position, FireExit.transform.rotation);
        var RB = b.GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(FireVector.x  *BulletSpeed,FireVector.y *BulletSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mousePos = Input.mousePosition;
        var screenPos = _Camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _Parent.position.z - _Camera.transform.position.z));
        var angle = Mathf.Atan2((screenPos.y - _Parent.position.y), (screenPos.x - _Parent.position.x));
        transform.position = _StartingPosition.position;
        transform.rotation = _StartingPosition.rotation;
        //transform.RotateAround(_Parent.position, new Vector3(0,0,1), angle);
        _Parent.eulerAngles = new Vector3(_Parent.eulerAngles.x, _Parent.eulerAngles.y, angle * Mathf.Rad2Deg);
        //Debug.Log(_Parent.position + " " + new Vector3(0, 0, 1) + " " + angle * Mathf.Rad2Deg);
         FireVector = new Vector2( Mathf.Cos(angle), Mathf.Sin(angle) );
    }
}
