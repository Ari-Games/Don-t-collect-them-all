using UnityEngine;
using UnityEngine.UI;

public class FlyStatus : MonoBehaviour 
{
    [SerializeField] float speed = 1;
    public float flyBarValue;

    private Image image;

    public bool IsFlying
    {
        get; set;
    }

    private void Start() 
    {
        IsFlying = false;
        image = GetComponent<Image>();
    }

    private void Update() 
    {
        flyBarValue = image.fillAmount;
        if(IsFlying)
            image.fillAmount -= Time.deltaTime*speed;
        else 
            image.fillAmount += Time.deltaTime*speed;
    }
}