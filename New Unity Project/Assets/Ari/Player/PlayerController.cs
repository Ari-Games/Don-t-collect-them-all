using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum Ground
{
    Hard,
    None
}

public class PlayerController : MonoBehaviour
{

    readonly Vector3 flippedScale = new Vector3(-1, 1, 1);
    [Header("Character")]
    [SerializeField] Animator animator = null;
    [SerializeField] Transform arm;
    [SerializeField] Transform puppet;

    [Header("Movement")]
    [SerializeField] float acceleration = 0.0f;
    [SerializeField] float maxSpeed = 0.0f;
    [SerializeField] float jumpForce = 0.0f;
    [SerializeField] float minFlipSpeed = 0.1f;
    [SerializeField] float jumpGravityScale = 1.0f;
    [SerializeField] float fallGravityScale = 1.0f;
    [SerializeField] float groundedGravityScale = 1.0f;
    [SerializeField] bool isCastingMagic = false;

    [Header("Skill")]
    [SerializeField] SkillController skillController;
    [SerializeField] FlyStatus flyStatus;

    private Vector2 movementInput;
    private Rigidbody2D controllerRigidbody;
    private Collider2D controllerCollider;
    private LayerMask hardGroundMask;
    private LayerMask launchObjectMask;
    Vector2 prevVelocity;
    Ground ground;
    Camera mainCamera;

    bool jumpInput;
    bool isJumping;

    bool isFlying;

    private int animatorGrounded;
    private int animatorRunningSpeed;
    private int animatorJump;
    private int animatorFly;

    private bool isFlipped = false;

    public ObjectOnLaunch objectToLaunch;


    public bool CanMove { get; set; }
    void Start()
    {
        mainCamera = Camera.main;
        CanMove = true;
        controllerRigidbody = GetComponent<Rigidbody2D>();
        controllerCollider = GetComponent<Collider2D>();
        hardGroundMask = LayerMask.GetMask("Ground Hard");
        launchObjectMask = LayerMask.GetMask("Launch");

        animatorGrounded = Animator.StringToHash("Grounded");
        animatorRunningSpeed = Animator.StringToHash("RunningSpeed");
        animatorJump = Animator.StringToHash("Jump");
        animatorFly = Animator.StringToHash("Fly");
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        var mouse = Mouse.current;
        if (!CanMove || keyboard == null)
            return;

        float moveHor = 0.0f;
        if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
        {
            moveHor = 1.0f;
        }
        else if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            moveHor = -1.0f;

        movementInput = new Vector2(moveHor, 0);
        if (!isJumping && keyboard.spaceKey.wasPressedThisFrame)
        {
            jumpInput = true;
        }

        Vector2 screenPoint = mainCamera.ScreenToWorldPoint(mouse.position.ReadValue());
        Vector2 handDir = screenPoint - (Vector2)arm.position;
        if (!isCastingMagic)
            arm.right = isFlipped ? -handDir : handDir;


        isFlying = keyboard.eKey.isPressed;

        if (keyboard.qKey.isPressed)
        {
            if (objectToLaunch == null)
            {
                Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, 3f, launchObjectMask);
                var obj = FindClosest(objects);
                if (obj)
                    objectToLaunch = obj.GetComponent<ObjectOnLaunch>();
            }
            else
            {

                objectToLaunch.CanLaunch = true;
                objectToLaunch.LaunchDir = handDir.normalized;
            }
        }
        else if (objectToLaunch)
        {
            objectToLaunch.CanLaunch = false;
            objectToLaunch = null;
        }

        if(mouse.leftButton.isPressed)
        {
            skillController.IncreasePower();
        }
        if(mouse.leftButton.wasReleasedThisFrame)
        {
            skillController.handDirection = handDir;
            skillController.BloodShoot();
        }
        
    
        
    }

    private void FixedUpdate()
    {
        UpdateVelocity();
        UpdateLayerMask();
        UpdateJump();
        UpdateGravityScale();
        UpdateDirection();
        UpdateFly();
        prevVelocity = controllerRigidbody.velocity;
    }

    private void UpdateVelocity()
    {
        Vector2 velocity = controllerRigidbody.velocity;
        velocity += movementInput * acceleration * Time.fixedDeltaTime;
        movementInput = Vector2.zero;
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        controllerRigidbody.velocity = velocity;
        if(!isFlying)
            animator.SetFloat(animatorRunningSpeed, Math.Abs(velocity.x) / maxSpeed);
    }

    private void UpdateLayerMask()
    {
        if (controllerCollider.IsTouchingLayers(hardGroundMask))
            ground = Ground.Hard;
        else
            ground = Ground.None;

        animator.SetBool(animatorGrounded, ground != Ground.None);
    }

    private void UpdateJump()
    {
        if(isFlying)
            return;
        if (ground == Ground.Hard && jumpInput)
        {
            controllerRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpInput = false;
            isJumping = true;
           
            animator.SetTrigger(animatorJump);
        }
        else if (isJumping && ground == Ground.Hard)
        {
            isJumping = false;
        }

    }

    private void UpdateFly()
    {
        if(isFlying && flyStatus.flyBarValue >0)
        {

            flyStatus.IsFlying = true;
            animator.SetFloat(animatorRunningSpeed,0f);
            controllerRigidbody.gravityScale = 0;
            controllerRigidbody.position += Vector2.up*Time.fixedDeltaTime;
            animator.SetTrigger(animatorFly);
        }
        else
            flyStatus.IsFlying = false;
    }

    private void UpdateGravityScale()
    {
        var gravityScale = groundedGravityScale;
        if (ground == Ground.None)
        { 
            gravityScale = controllerRigidbody.velocity.y > 0.0f ? jumpGravityScale : fallGravityScale;
        }
        controllerRigidbody.gravityScale = gravityScale;
    }


    private void UpdateDirection()
    {
        if (controllerRigidbody.velocity.x > minFlipSpeed && isFlipped)
        {
            isFlipped = false;
            puppet.localScale = Vector3.one;
        }
        else if (controllerRigidbody.velocity.x < -minFlipSpeed && !isFlipped)
        {
            isFlipped = true;
            puppet.localScale = flippedScale;
        }
    }

    private Collider2D FindClosest(Collider2D[] colliders)
    {
        if (colliders.Length == 0)
            return null;
        float mimLeng = Vector2.Distance(colliders[0].transform.position, transform.position);
        Collider2D obj = colliders[0];
        for (int i = 1; i < colliders.Length; i++)
        {
            float lenToCollider = Vector2.Distance(transform.position, colliders[i].transform.position);
            if (lenToCollider < mimLeng)
            {
                mimLeng = lenToCollider;
                obj = colliders[i];
            }
        }

        return obj;
    }
}
