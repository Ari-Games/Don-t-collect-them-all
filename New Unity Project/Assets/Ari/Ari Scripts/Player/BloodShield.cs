using UnityEngine;

[RequireComponent(typeof(Damageable))]
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

    [SerializeField] float cooldown = 2f;
    [SerializeField] float timer;
    [SerializeField] Damageable damageable;

    public float CoolDown
    {
        get {return cooldown;}
    }

    public float Timer
    {
        get { return timer; }
    }

    bool isUsing = false;

    private void Start() 
    {
        damageable = GetComponent<Damageable>();
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
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if(isUsing)
        {
            timer+=Time.deltaTime;
            if(timer >= cooldown)
            {
                isUsing = false;
                CanUse = true;
                timer = 0f;
                damageable.HealthPoint = damageable.StandartHP;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
            if (damageable.HealthPoint <= 0)
            {
                damageable.HealthPoint = 1;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }
}