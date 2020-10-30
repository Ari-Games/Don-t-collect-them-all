using System;
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
    [SerializeField] ParticleSystem Explosion;
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
        Explose();
        print("BOOM");
    }

    private void Explose()
    {
        var expl = Instantiate(Explosion,transform.position,Quaternion.identity);
        expl.Play();
        Destroy(expl.gameObject, 5);
        Destroy(this.gameObject);
    }
}
