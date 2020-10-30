using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Enemy
{
    float timeOf;
    bool _shootTrigger = false;

    GameObject _target;
    [SerializeField] GameObject FireBall;
    [SerializeField] float frequency = 1f;
    void Start()
    {
        timeOf = Time.time;
    }
    private void FixedUpdate()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision +" "+ collision.tag);
        if (collision.tag!="Player")
        {
            return;
        }
        print("fireball");

        _target = collision.gameObject;
        _shootTrigger = true;

    }
    void Update()
    {
        if (_shootTrigger && (timeOf)>= frequency)
        {
            var ball = Instantiate(FireBall, transform.position, Quaternion.identity).GetComponent<Fireball>();
            Destroy(ball.gameObject, 5f);
            var to = (_target.transform.position - transform.position);
            to.y += 1;
            ball.DirectTo(to, 5);
            timeOf = 0;
        }
        timeOf += Time.deltaTime;
    }
    public override void Death()
    {
        Destroy(this.gameObject);
    }
    
}
