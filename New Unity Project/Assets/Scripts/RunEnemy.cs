using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : Enemy
{

    float timeOf;
    bool _shootTrigger = false;
    GameObject _target;
    Rigidbody2D _rigidbody2D; 
    [Header("Shoot Logic")]
    [SerializeField] float ForDamageDistance = 1;
    [Header("Enemy Settings")]
    [SerializeField] float Velocity = 2f;
    
    void Start()
    {
        timeOf = Time.time;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (_target && (_target.transform.position - transform.position).magnitude >= 0.5)
        {
            MoveLogic();            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }
        _target = collision.gameObject;
        _shootTrigger = true;

    }
    void Update()
    {
        if (_target && (_target.transform.position - transform.position).magnitude <=ForDamageDistance)
        {
            ShootLogic();
            
        }
        timeOf += Time.deltaTime;
    }

    private void MoveLogic()
    {
        var direction = (_target.transform.position - transform.position).normalized;
        _rigidbody2D.MovePosition(transform.position + direction * Velocity * Time.fixedDeltaTime);
    }

    private void ShootLogic()
    {
        Damageable playerHealth;
        if (_target.TryGetComponent<Damageable>(out playerHealth))
        {
            playerHealth.Damage(10);
        }
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }

}
