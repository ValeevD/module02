using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform visual;
    public float moveForce;
    public float jumpForce;

    Rigidbody2D rigidBody2D;
    TriggerDetector triggerDetector;
    Animator animator;
    float visualDirection;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        visualDirection = 1.0f;
        rigidBody2D = GetComponent<Rigidbody2D>();
        triggerDetector = GetComponentInChildren<TriggerDetector>();
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveLeft()
    {
        if (triggerDetector.inTrigger)
            rigidBody2D.AddForce(new Vector2(-moveForce, 0.0f), ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        if (triggerDetector.inTrigger)
            rigidBody2D.AddForce(new Vector2(moveForce, 0.0f), ForceMode2D.Impulse);
    }

    public void Jump()
    {
        if(triggerDetector.inTrigger)
            rigidBody2D.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead)
        {
            Destroy(gameObject);
            return;
        }

        float velocity = rigidBody2D.velocity.x;

        if (velocity < -0.05f) {
            visualDirection = -1.0f;
        } else if (velocity > 0.05f) {
            visualDirection = 1.0f;
        }

        Vector3 scale = visual.localScale;
        scale.x = visualDirection;
        visual.localScale = scale;

        animator.SetFloat("speed", Mathf.Abs(velocity));

        //if (!triggerDetector.inTrigger)
        animator.SetBool("Jumping", !triggerDetector.inTrigger);
    }

    public void SetDead()
    {
        isDead = true;
    }
}
