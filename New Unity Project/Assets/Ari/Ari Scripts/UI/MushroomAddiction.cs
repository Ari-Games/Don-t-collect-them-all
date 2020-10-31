using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomAddiction : MonoBehaviour
{

    [SerializeField] float standartAddictionValue = 0.5f;
    [SerializeField] float addictionSpeed = 0.2f;
    [SerializeField] Image addictionImage;
    [SerializeField] GameObject deathPanel;
    private bool flag = false;



    // Update is called once per frame
    void Update()
    {
        if(addictionImage.fillAmount >= 0.95f || addictionImage.fillAmount <= 0.05f)
        {
            if (!flag)
            {
                flag = true;
                deathPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        addictionImage.fillAmount -=Time.deltaTime * addictionSpeed;
        
    }

    private void OnEnable()
    {
        addictionImage.fillAmount = standartAddictionValue;
    }

    public void AddAddiction(float value)
    {
        addictionImage.fillAmount += value;
    }
}
