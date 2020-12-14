using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class Lazer : MonoBehaviour
{
    public float damage = 12;
    public float speed = 4.0f;
    public Vector3 direction = Vector3.right + Vector3.up;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliders;
    

    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float horizontalForce;
    public float joystickVerticleSensitivity;
    public float verticleForce;

    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _CheckCollision();
        //if (GetButtonDown("Fire"))
            fire();
        //joystick = ("horizontal");
    }

    public void Initialize()
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void _CheckCollision()
    {
        Physics2D.GetContacts(boxCollider, contactFilter, colliders);

        if (colliders.Count > 0)
        {
            if (colliders[0] != null)
            {
                //Bullet.Instance().ReturnBullet(PoolType.PLAYER, gameObject);
                colliders.Clear();
            }
        }
    }

    public void fire()
    {
       // var firedBullet = Instantiate(Lazer, barrel.position, barrel.rotation);
        //firedBullet.AddForce(barrel.up * bulletSpeed);
    }
}
