using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{

    [SerializeField] Image powerImage;
    [SerializeField] Image shieldImage;
    [SerializeField] BloodBalls bloodPower;
    [SerializeField] BloodShield bloodShield;
    // Start is called before the first frame update
    // void Start()
    // {
    //     bloodPower = GameObject.FindWithTag("Pool Spot").GetComponent<BloodBalls>(); 
    //     bloodShield = GameObject.FindWithTag("Shield").GetComponent<BloodShield>();
    // }

    // Update is called once per frame
    void Update()
    {
        powerImage.fillAmount = bloodPower.ShootPower;
        //shieldImage.fillAmount = bloodShield.Timer / bloodShield.CoolDown;
        if(bloodShield.Timer != 0)
            shieldImage.enabled = false;
        else
            shieldImage.enabled = true;
    }
}
