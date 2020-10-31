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

    [SerializeField] float cooldown = 4f;
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
                this.gameObject.SetActive(false);
            }
            if (damageable.HealthPoint <= 0)
                this.gameObject.SetActive(false);
        }
    }
}