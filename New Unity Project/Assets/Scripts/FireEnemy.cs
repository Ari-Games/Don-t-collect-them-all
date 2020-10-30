using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FireEnemy : Enemy
{
    float timeOf;
    bool _shootTrigger = false;
    GameObject _target;
    Rigidbody2D _rigidbody2D;
    [Header("Shoot Settings")]
    [SerializeField] GameObject FireBall;
    [SerializeField] float frequency = 1f;
    [Header("Enemy Settings")]
    [SerializeField] float Velocity = 2f;
    void Start()
    {
        timeOf = Time.time;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (_target && (_target.transform.position - transform.position).magnitude >= 5)
        {
            var direction = (_target.transform.position - transform.position).normalized;
            _rigidbody2D.MovePosition(transform.position + direction*Velocity*Time.fixedDeltaTime);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag!="Player")
        {
            return;
        }
        _target = collision.gameObject;
        _shootTrigger = true;

    }
    void Update()
    {
        if (_shootTrigger && (timeOf)>= frequency)
        {
            ShootLogic();
            MoveLogic();
        }
        timeOf += Time.deltaTime;
    }

    private void MoveLogic()
    {
        
    }

    private void ShootLogic()
    {
        var ball = Instantiate(FireBall, transform.position, Quaternion.identity).GetComponent<Fireball>();
        Destroy(ball.gameObject, 5f);
        var to = (_target.transform.position - transform.position);
        to.y += 1;
        ball.DirectTo(to, 5);
        timeOf = 0;
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }
    
}
