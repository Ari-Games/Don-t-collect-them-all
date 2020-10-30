using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Vector3 _direction;
    int _force = 0;

    [SerializeField] int Speed = 100;
    [SerializeField] GameObject SpriteOfBall;
    
    void Start()
    {
        //_rigidbody2D = GetComponent<Rigidbody2D>();
       
    }
    private void FixedUpdate()
    {
        //_rigidbody2D.AddForce(_direction.normalized * _force);
    }
    public void DirectTo(Vector3 direction,int force)
    {
        _direction = direction;
        _force = force;
        
    }
    void Update()
    {
        //transform.LookAt(_direction * Time.deltaTime);
        transform.Translate(_direction.normalized*Speed * Time.deltaTime);
        SpriteOfBall.transform.LookAt(_direction);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }
        print("BOOM");
    }
}
