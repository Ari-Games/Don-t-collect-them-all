using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SkillController : MonoBehaviour 
{

    public class Ball
    {
        public GameObject gameObject;
        public Transform transform;
        public float lifeTime;
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
            shootPower += Time.deltaTime*0.7f;
    }

    public void BloodShoot()
    {

        Ball blood = GetFromPool();
        blood.gameObject.SetActive(true);
        blood.transform.position = handSpot.position;
        blood.transform.right = handDirection;
        blood.transform.localScale = new Vector3(transform.localScale.x + shootPower, 
            transform.localScale.y + shootPower, transform.localScale.z);
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
            objToShoot.transform.position += objToShoot.transform.right.normalized*Time.deltaTime*bloodSpeed;
            objToShoot.lifeTime += Time.deltaTime;
            if(objToShoot.lifeTime > bloodLifeTime)
                BloodBallReturn(objToShoot);
        }
    }
}