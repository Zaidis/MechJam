using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputAsset;
    [SerializeField] private InputActionMap player;
    [SerializeField] private InputAction movement;
    [SerializeField] private Camera playerCamera;
    public float drift = 0.3f;
    private Vector2 move = Vector2.zero;
    public float speed = 4f;
    private Rigidbody2D rb;
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        movement = player.FindAction("Move");
        player.Enable();
    }
    private void OnDisable()
    {
        player.Disable();
    }
    private void FixedUpdate()
    {
        move += movement.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * speed;
        move += movement.ReadValue<Vector2>().y * GetCameraUp(playerCamera) * speed;
        rb.AddForce(move, ForceMode2D.Impulse);
        move = Vector2.zero;
        if(rb.velocity.sqrMagnitude > speed * speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
       
    }

    private Vector2 GetCameraUp(Camera playerCamera)
    {
        Vector2 up = playerCamera.transform.up;
        return up.normalized;
    }

    private Vector2 GetCameraRight(Camera playerCamera)
    {
        Vector2 right = playerCamera.transform.right;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext context)
    {

    }
    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        
    }
    
}
