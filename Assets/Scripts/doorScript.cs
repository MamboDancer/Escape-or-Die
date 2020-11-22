using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doorScript : MonoBehaviour
{
   
    private static bool isDown = false, isUp = false, isLeft= false, isRight= false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (generateLevel.returnCanGo())
        {
            if (collision.gameObject.tag == "Player" && isDown)
            {
                moveCharacter.setPosition(-0.2f, 1.9f);
                generateLevel.changeDestroy();
                isDown = false;
                
            }
            if (collision.gameObject.tag == "Player" && isUp)
            {
                moveCharacter.setPosition(-0.2f, -1.9f);
                generateLevel.changeDestroy();
                isUp = false;
                
            }
            if (collision.gameObject.tag == "Player" && isRight)
            {
                moveCharacter.setPosition(4.9f, 0f);
                generateLevel.changeDestroy();
                isRight = false;
                
            }
            if (collision.gameObject.tag == "Player" && isLeft)
            {
                moveCharacter.setPosition(-5.2f, 0f);
                generateLevel.changeDestroy();
                isLeft = false;
               
            }
        }
    }
    public static bool getUp()
    {
        return isUp;
    }
    public static bool getDown()
    {
        return isDown;
    }
    public static bool getRight()
    {
        return isLeft;
    }
    public static bool getLeft()
    {
        return isRight;
    }
    public static void setUp()
    {
        isDown = true;
        isUp = false;
        isRight = false;
        isLeft = false;
        

    }
    public static void setRight()
    {
        isLeft = true;
        isRight = false;
        isUp = false;
        isDown = false;



    }
    public static void setDown()
    {
        isUp = true;
        isDown = false;
        isRight = false;
        isLeft = false;


    }
    public static void setLeft()
    {
        isRight = true;
        isUp = false;
        isDown = false;
        isLeft = false;

    }
}
