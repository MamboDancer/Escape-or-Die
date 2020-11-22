using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject circle, dot;
    private static Rigidbody2D rb;
    private float moveSpeed;
    private Touch oneTouch;
    private Vector2 touchPosition;
    private static Vector2 moveDirection;
    public static bool canMove;
    public Sprite left, right;
    public SpriteRenderer character;
    public AudioSource moveSound;
    private bool canSound = true;
    void Start()
    {
        canMove = false;
        rb = GetComponent<Rigidbody2D>();
        circle.SetActive(false);
        dot.SetActive(false);
        moveSpeed = 3f;
    }
    public static void setPosition(float x,float y)
    {
        rb.transform.position = new Vector2(x, y);
    }
    public static void setMove(bool state)
    {
       
        canMove = state;
    }
    // Update is called once per frame
    IEnumerator setMoveSound()
    {
        
        moveSound.Play();
        yield return new WaitForSeconds(0.4f);
        canSound = true;



    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            oneTouch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);
            switch (oneTouch.phase)
            {
                case TouchPhase.Began:
                    circle.SetActive(true);
                    dot.SetActive(true);

                    circle.transform.position = touchPosition;
                    dot.transform.position = touchPosition;
                    break;
                case TouchPhase.Stationary:
                    MovePlayer();
                    break;
                case TouchPhase.Moved:
                    MovePlayer();
                    break;
                case TouchPhase.Ended:
                    circle.SetActive(false);
                    dot.SetActive(false);

                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }
    private void MovePlayer()
    {
        dot.transform.position = touchPosition;
        float speed = 3f + (generateLevel.level / 30);
        dot.transform.position = new Vector2(
            Mathf.Clamp(dot.transform.position.x,
            circle.transform.position.x - 0.8f,
            circle.transform.position.x + 0.8f),
            Mathf.Clamp(dot.transform.position.y,
            circle.transform.position.y - 0.8f,
            circle.transform.position.y + 0.8f));

        moveDirection = (dot.transform.position - circle.transform.position).normalized;
        if(moveDirection.x > 0)
        {
            character.sprite = right;
        }
        else
        {
            character.sprite = left;
        }

        if (canMove)
        {
            if (canSound)
            {
                canSound = false;
                StartCoroutine(setMoveSound());
            }

            if (speed > 5f) speed = 5f;

            rb.velocity = moveDirection * speed;
        }
        else
        {
            rb.velocity = moveDirection * 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "gateColliderDown") doorScript.setUp();
        if (collision.gameObject.name == "gateColliderUp") doorScript.setDown();
        if (collision.gameObject.name == "gateColliderLeft") doorScript.setRight();
        if (collision.gameObject.name == "gateColliderRight") doorScript.setLeft();
    }
    public static Vector2 getDirection()
    {
        return moveDirection;
    }
}