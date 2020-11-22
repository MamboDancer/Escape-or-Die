using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MechnicControler : MonoBehaviour
{
    private float speed;
    public float defSpeed;
    public float sndSpeed;
    private float health = 3;
    public bool attacking;
    public SpriteRenderer skeleton;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Transform playerPos;
    private string action;

    private int TimeForMove;
    private long timeMoveBegin;
    private float xAxisAction = 0, yAxisAction = 0;
    private bool fst_time = true;

    private long fD_startTime;
    private long fD_TimeForMove;

     public float  getHp()
    {
        return health;
    }
    public void substractHp(float num)
    {
        health = health - num;
    }
     public void  addHp(float num)
    {
        health = health + num;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = defSpeed;
        action = "simpleMovement";
    }
    
    private void Update()
    {
        if (moveCharacter.canMove)
        {
            defSpeed = 0.5f;
            sndSpeed = 0.5f;
        }
        else
        {
            defSpeed = 0f;
            sndSpeed = 0f;
        }

       
        MechnicMotionController();
        if (attacking) action = "runToPlayer";
    }
    void setSpeed(float spd)
    {
        defSpeed = spd;
        sndSpeed = spd;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        attacking = false;

        if (collision.gameObject.tag == "Player")
        {
            if (action == "runToPlayer")
            {
                Debug.Log("Hit!");
                attacking = false;
                action = "runFromPlayer";
            }
            else
            {
                action = "runFromPlayer";
                TimeForMove = random(2000, 3000);
                timeMoveBegin = GetTimeNow();
            }
        }
        
        if (collision.collider.name == "left")
        {
            action = "freezeDirection";
            xAxisAction = 1;
            fD_startTime = GetTimeNow();
            fD_TimeForMove = random(3000, 5000);
        }

        if (collision.collider.name == "right")
        {
            action = "freezeDirection";
            xAxisAction = -1;
            fD_startTime = GetTimeNow();
            fD_TimeForMove = random(3000, 5000);
        }

        if (collision.collider.name == "up")
        {
            action = "freezeDirection";
            yAxisAction = -1;
            fD_startTime = GetTimeNow();
            fD_TimeForMove = random(3000, 5000);
        }

        if (collision.collider.name == "down")
        {
            action = "freezeDirection";
            yAxisAction = 1;
            fD_startTime = GetTimeNow();
            fD_TimeForMove = random(3000, 5000);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = defSpeed;
        }
    }

    //###################### my functions ##########################

    void MechnicMotionController()
    {
        if (action == "runToPlayer")
        {
            speed = defSpeed;
            if (playerPos.position.x > rb.position.x) xAxisAction = 1;
            if (playerPos.position.x < rb.position.x) xAxisAction = -1;
            if (playerPos.position.x == rb.position.x) xAxisAction = 0;

            if (playerPos.position.y > rb.position.y) yAxisAction = 1;
            if (playerPos.position.y < rb.position.y) yAxisAction = -1;
            if (playerPos.position.y == rb.position.y) yAxisAction = 0;

            Vector2 moveInput = new Vector2(xAxisAction, yAxisAction);
            moveVelocity = moveInput * speed;
            if (moveVelocity.x >= playerPos.position.x) skeleton.flipX = false;
            else skeleton.flipX=true;
        }
        if (action == "simpleMovement")
        {
            if (fst_time)
            {
                fst_time = false;
                
                xAxisAction = random(-1, 2);
                yAxisAction = random(-1, 2);
            }

            if (timeMoveBegin + TimeForMove <= GetTimeNow())
            {
                TimeForMove = random(2000, 4000);
                timeMoveBegin = GetTimeNow();
                xAxisAction = random(-1, 2);
                yAxisAction = random(-1, 2);
            }
            speed = sndSpeed;
            Vector2 moveInput = new Vector2(xAxisAction, yAxisAction);
            moveVelocity = moveInput * speed;
        }
        if(action == "runFromPlayer")
        {
            if (timeMoveBegin + TimeForMove <= GetTimeNow())
            {
                action = "simpleMovement";
            }
            if (playerPos.position.x > rb.position.x) xAxisAction = -1;
            if (playerPos.position.x < rb.position.x) xAxisAction = 1;
            if (playerPos.position.x == rb.position.x) xAxisAction = 0;

            if (playerPos.position.y > rb.position.y) yAxisAction = -1;
            if (playerPos.position.y < rb.position.y) yAxisAction = 1;
            if (playerPos.position.y == rb.position.y) yAxisAction = 0;
            Vector2 moveInput = new Vector2(xAxisAction, yAxisAction);
            speed = defSpeed;
            moveVelocity = moveInput * speed;
        }
        if (action == "freezeDirection") // fD
        {
            if (fD_startTime + fD_TimeForMove <= GetTimeNow())
            {
                action = "simpleMovement";
            }
            speed = sndSpeed;
            Vector2 moveInput = new Vector2(xAxisAction, yAxisAction);
            moveVelocity = moveInput * speed;
        }
    }

    long GetTimeNow()//milliseconds
    {
        return System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
    }

    float random(float a, float b)
    {
        return Random.Range(a, b);
    }
    int random(int a, int b)
    {
        return Random.Range(a, b);
    }
}