using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera _Camera;
    private Vector2 FireVector;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        _Camera = FindObjectOfType<Camera>();
    }

    public void OnFire()
    {
        var b = Instantiate(Bullet, transform.position, transform.rotation);
        var RB = b.GetComponent<Rigidbody2D>();
        RB.velocity = new Vector2(FireVector.x,FireVector.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mousePos = Input.mousePosition;
        var screenPos = _Camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - _Camera.transform.position.z));
        var angle = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle * Mathf.Rad2Deg);

        FireVector = new Vector2( Mathf.Cos(angle), Mathf.Sin(angle) );
    }
}
