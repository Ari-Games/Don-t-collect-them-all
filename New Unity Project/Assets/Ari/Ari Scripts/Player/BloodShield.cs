using UnityEngine;

public class BloodShield : MonoBehaviour
{
    public bool CanUse
    {
        get;  set;
    }

    public bool IsInput
    {
        get; set;
    }

    [SerializeField] float cooldown = 4f;
    [SerializeField] float timer;
    [SerializeField] int shieldHP = 1;


    int standartHPValue;
    bool isUsing = false;

    private void Start() 
    {
        standartHPValue = shieldHP;
        timer = 0f;
        CanUse = true;
    }

    private void Update() 
    {
        if(IsInput && CanUse)
        {
            CanUse = false;
            isUsing = true;
            IsInput = false;
        }
        if(isUsing)
        {
            timer+=Time.deltaTime;
            if(timer >= cooldown || shieldHP <=0)
            {
                isUsing = false;
                CanUse = true;
                timer = 0f;
                shieldHP = standartHPValue;
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Damage()
    {
        shieldHP -= 1;
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     // if (other.collider.CompareTag("Bullet"))
    //     // {
    //     //     Damage();
    //     // }
    // }
}