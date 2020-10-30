using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class BloodBalls : MonoBehaviour 
{

    public class Ball
    {
        public GameObject gameObject;
        public Transform transform;
        public float lifeTime;
        public int damage;
        public Ball(GameObject gameObject)
        {
            this.gameObject = gameObject;
            this.transform = gameObject.transform;
        }
    }

    [SerializeField] float shootPower;
    [SerializeField] float bloodSpeed = 2f;
    [SerializeField] float bloodLifeTime = 3f;
    List<Ball> bloodBallsPool = new List<Ball>();
    List<Ball> bloodBallsUse = new List<Ball>();

    [SerializeField] GameObject bloodPrefab;

    [SerializeField] Transform handSpot;
    [SerializeField] Transform poolSpot;
    [SerializeField] LayerMask collisionMask = default;
    
    RaycastHit2D hit;
    [SerializeField] int damage = 5;

    public float ShootPower
    {
        get { return shootPower;}
    }
    Vector3 scaleBefore;

    public Vector3 handDirection;

    public bool ShootPressed
    {
        get; set;
    }
    
    private void Start() 
    {
        scaleBefore = bloodPrefab.transform.localScale;
        poolSpot = GameObject.FindWithTag("Pool Spot").transform;
        shootPower = 0;
        ShootPressed = false;

        for(int i = 0; i < 20; i++)
        {
            bloodBallsPool.Add(CreateInPool());
        }
    }

    public void IncreasePower()
    {
        if(shootPower >= 1f)
            shootPower = 1f;
        else 
            shootPower += Time.deltaTime;
    }

    public void BloodShoot()
    {

        if (Camera.main.GetComponent<CinemachineImpulseSource>())
            Camera.main.GetComponent<CinemachineImpulseSource>().GenerateImpulse();

        Ball blood = GetFromPool();
        blood.gameObject.SetActive(true);
        blood.transform.position = handSpot.position;
        blood.transform.right = handDirection;
        blood.transform.localScale = new Vector3(transform.localScale.x + shootPower, 
            transform.localScale.y + shootPower, transform.localScale.z);
        int damagePower = (int)( (int)(shootPower*100)*damage /100);
        blood.damage = damagePower + damage;
        shootPower = 0;
        blood.lifeTime = 0;
    }



    private Ball CreateInPool()
    {
        GameObject addObj = Instantiate(bloodPrefab,poolSpot.transform);
        addObj.SetActive(false);
        Ball ball = new Ball(addObj);
        return ball;
    }

    private Ball GetFromPool()
    {
        Ball obj = null;
        if(bloodBallsPool.Count > 0)
        {
            obj = bloodBallsPool[0];
            bloodBallsPool.RemoveAt(0);
        }
        else
        {
            obj = CreateInPool();
        }

        bloodBallsUse.Add(obj);
        return obj;
    }

    private void BloodBallReturn(Ball ball)
    {
        ball.gameObject.SetActive(false);
        bloodBallsUse.Remove(ball);
        ball.transform.localScale = scaleBefore;
        bloodBallsPool.Add(ball);
    }

    private void Update() {
        for(int i = bloodBallsUse.Count - 1; i >= 0; i--)
        {
            Ball objToShoot = bloodBallsUse[i];
            Vector3 objStartPos = objToShoot.transform.position;
            objToShoot.transform.position += objToShoot.transform.right.normalized*Time.deltaTime*bloodSpeed;
            objToShoot.lifeTime += Time.deltaTime;

            hit = Physics2D.Linecast(objStartPos, objToShoot.transform.position, collisionMask.value);
            if(hit && hit.collider.CompareTag("Enemy"))
            {
                if(hit.collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.PushEnemy(objToShoot.damage);
                    BloodBallReturn(objToShoot);
                }
            }
            if(objToShoot.lifeTime > bloodLifeTime)
                BloodBallReturn(objToShoot);
        }
    }
}