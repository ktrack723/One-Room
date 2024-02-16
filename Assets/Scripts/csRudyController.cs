using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class csRudyController : MonoBehaviour
{
    [Header("Fetch on start")]

    [SerializeField] private Animator animator;

    [Header("Parameters")]

    [SerializeField] private float speed;

    [Header("Debug")]

    [SerializeField] private bool isMoving;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private float dashVelocityMultiplier;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    private void Update()
    {
        ProcessMoveInput();
    }



    private void ProcessMoveInput()
    {
        if (LeanTween.isTweening(gameObject) == true)
        {
            Move();

            return;
        }

        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A) == true)
        {
            velocity.x -= 1.0f;
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            velocity.x += 1.0f;
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            velocity.z += 1.0f;
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            velocity.z -= 1.0f;
        }

        if (velocity.x != 0 && velocity.z != 0)
        {
            velocity /= 1.414f;
        }

        isMoving = (velocity != Vector3.zero);

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        Move();
    }



    private void Dash()
    {
        LeanTween.value(gameObject, UpdateDash, 1, 5, 0.1f).setEaseInOutCubic().setOnComplete(()=>
        {
            LeanTween.value(gameObject, UpdateDash, 5, 1, 0.25f).setEaseInOutCubic();
        });
    }



    private void UpdateDash(float arg)
    {
        dashVelocityMultiplier = arg;
    }



    private void Move()
    {
        transform.Translate((velocity * speed * dashVelocityMultiplier) * Time.deltaTime);
    }
}