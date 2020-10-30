using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBar : MonoBehaviour
{

    private Image image;
    [SerializeField] BloodBalls bloodPower;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        bloodPower = GameObject.FindWithTag("Pool Spot").GetComponent<BloodBalls>(); 
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = bloodPower.ShootPower;
    }
}
