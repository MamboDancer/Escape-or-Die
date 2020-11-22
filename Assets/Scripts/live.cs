using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class live : MonoBehaviour
{
    public Transform endScreen;
    public static bool isImmortal = false;
    private static int hp = 100;
    public Transform enemy;
    public SpriteRenderer playerSprite;
    public AudioSource hitSound;
    void Start()
    {
    }
    IEnumerator endgame()
    {

        endScreen.position = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(3f);
        endScreen.position = new Vector3(50f, 0f, 0f);
        changeHP(100);
        generateLevel.level = 0;
       
        SceneManager.LoadScene(0);
        

    }
    IEnumerator flash(int repeats, float delay)
    {
        isImmortal = true;
        for (int i = 0; i < repeats; i++)
        {
            playerSprite.sortingOrder = -1;
            yield return new WaitForSeconds(delay);
            playerSprite.sortingOrder = 2;
            yield return new WaitForSeconds(delay);
        }
        isImmortal = false;
    }
    public static int getHP()
    {
        return hp;
    }
    public static void changeHP(int value)
    {
        hp += value;
    }
    void Update()
    {
        if (hp <= 0) { StartCoroutine(endgame()); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isImmortal)
        {
            if (collision.gameObject.tag == "enemy"|| collision.gameObject.tag == "spike" )
            {
                hitSound.Play();
                if((int)(-5 + generateLevel.level / 4) <= 50)
                {
                    changeHP((int)(-5 + generateLevel.level / 4));
                }
                else
                {
                    changeHP(-50);
                }
                StartCoroutine(flash(10, 0.1f));
            }
        }
    }
    
}
