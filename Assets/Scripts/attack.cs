using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField]
    private Vector2 touchPosition;
    public Transform player,attackSprite;
    private GameObject enable,attackObj;
    public bool atk;
    public static float attackSpeed = 0.7f;
    private float  angle;
    public AudioSource attackSound;
    // Start is called before the first frame update
    public Vector2 getAngle()
    {
        angle = Vector2.Angle(Vector2.right, player.position - transform.position);
        return new Vector3(0f, 0f, transform.position.y < player.position.y ? angle + 90 : -angle + 90);
    }
    void Start()
    {
        
        atk = true;
        
    }
    public static void setAttackSpeed(float num)
    {
        attackSpeed -= num;
    }
    IEnumerator swing()
    {
        float angle;
        if (Input.touchCount > 0)
        {
            var oneTouch = Input.GetTouch(1);
            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);
            attackSprite.transform.position = touchPosition;
            switch (oneTouch.phase)
            {
                case TouchPhase.Began:

                    
                    break;
                case TouchPhase.Stationary:
                    atk = false;
                    attackSound.Play();
                    transform.position = new Vector2(player.position.x, player.position.y) + moveCharacter.getDirection();
                    angle = Vector2.Angle(Vector2.right, player.position - transform.position);
                    transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < player.position.y ? angle+90 : -angle+90);
                    yield return new WaitForSeconds(0.2f);
                    transform.position = new Vector2(20, 20);
                    attackSprite.position = new Vector2(20, 20);
                    yield return new WaitForSeconds(attackSpeed);

                    atk = true;
                    break;
                case TouchPhase.Moved:


                   
                    atk = false;
                    attackSound.Play();
                    transform.position = new Vector2(player.position.x, player.position.y) + moveCharacter.getDirection();
                    angle = Vector2.Angle(Vector2.right, player.position - transform.position);
                    transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < player.position.y ? angle : -angle);
                    yield return new WaitForSeconds(0.2f);
                    transform.position = new Vector2(20, 20);
                    attackSprite.position = new Vector2(20, 20);
                    yield return new WaitForSeconds(attackSpeed);
                    atk = true;

                    break;
                case TouchPhase.Ended:
                    yield return new WaitForSeconds(0.2f);
                    transform.position = new Vector2(20, 20);
                    attackSprite.position = new Vector2(20, 20);
                    yield return new WaitForSeconds(attackSpeed);
                    atk = true;
                    break;
            }
        }
            
            
    }
    
   
    // Update is called once per frame
    void Update()
    {
        if (atk)
        {
            StartCoroutine(swing());
        }
    }
}