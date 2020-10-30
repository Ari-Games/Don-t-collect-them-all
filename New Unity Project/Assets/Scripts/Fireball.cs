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
    Vector3 _initPosition;
    [SerializeField] int Speed = 100;
    [SerializeField] GameObject SpriteOfBall;
    [SerializeField] ParticleSystem Explosion;
    void Start()
    {
        _initPosition = transform.position;
    }
    private void FixedUpdate()
    {
        
    }
    public void DirectTo(Vector3 direction,int force)
    {
        _direction = direction;
        _force = force;
        
    }
    void Update()
    {

        transform.Translate(_direction.normalized*Speed * Time.deltaTime);
        SpriteOfBall.transform.LookAt(_initPosition+_direction);        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == this.gameObject)
        {
            return;
        }
        Explose();
        TakeHealth(collision.gameObject);
        
    }

    private void TakeHealth(GameObject player)
    {
        var pl = player.GetComponent<Damageable>();
        if (pl!=null)
        {
            pl.Damage(10);
        }
    }

    private void Explose()
    {
        var expl = Instantiate(Explosion,transform.position,Quaternion.identity);
        expl.Play();
        Destroy(expl.gameObject, 5);
        Destroy(this.gameObject);
    }
}
