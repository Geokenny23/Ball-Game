using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFrozen;

    private float movementX;
    private float movementY;

    [SerializeField] private float speed;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        gameManager.OnStageCleared += Freeze;
        gameManager.OnGameOver += Freeze;
    }

    private void OnDisable()
    {
        gameManager.OnStageCleared -= Freeze;
        gameManager.OnGameOver -= Freeze;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        if (isFrozen) return;

        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            gameManager.PickupCollected();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }

    private void Freeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}

