using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FireEnemy : Enemy
{
    float timeOf;
    bool _shootTrigger = false;
    
    Rigidbody2D _rigidbody2D;
    [Header("Shoot Settings")]
    [SerializeField] GameObject FireBall;
    [SerializeField] float frequency = 1f;
    [SerializeField] float ActivateDistance = 10;
    [Header("Enemy Settings")]
    [SerializeField] float Velocity = 2f;
    [SerializeField] GameObject _target;
    void Start()
    {
        timeOf = Time.time;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        if (_shootTrigger &&  _target && (_target.transform.position - transform.position).magnitude >= 5 )
        {
            var direction = (_target.transform.position - transform.position).normalized;
            if (direction.x < 0)
            {
                var rot = transform.rotation.eulerAngles;
                rot.y = 0;
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rot));                
            }
            else
            {
                var rot = transform.rotation.eulerAngles;
                rot.y = -180;
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rot));
            }
            _rigidbody2D.MovePosition(transform.position + direction*Velocity*Time.fixedDeltaTime);
        }
        
    }
    
    
    void Update()
    {
        if ((_target.transform.position - transform.position).magnitude <= ActivateDistance)
        {
            _shootTrigger = true;
        }
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
