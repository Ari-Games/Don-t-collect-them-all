using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomAddiction : MonoBehaviour
{

    [SerializeField] float standartAddictionValue = 0.5f;
    [SerializeField] float addictionSpeed = 0.2f;
    [SerializeField] Image addictionImage;



    // Update is called once per frame
    void Update()
    {
        if(addictionImage.fillAmount >= 0.95f || addictionImage.fillAmount <= 0.05f)
        {
            //TODO GAMEOVER
            print("GAME OVER");
            return;
        }
        addictionImage.fillAmount -=Time.deltaTime * addictionSpeed;
        
    }

    private void OnEnable()
    {
        addictionImage.fillAmount = standartAddictionValue;
    }

    public void AddAddiction(float value)
    {
        addictionImage.fillAmount = value;
    }
}
