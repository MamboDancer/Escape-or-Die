using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class generateLevel : MonoBehaviour
{
    public SpriteRenderer doorSprite;
    public Sprite dclosed, dopened;
    public GameObject floor, wall, door,spike,enemy, bar, state,mainEnemy;
    public SpriteRenderer sprWall, sprFloor,sprSpike,sprEnemy;
    public Sprite b1, b2, b3;
    public Sprite e1, e2, e3;
    public Transform prefabFloor, prefabWall, prefabDoor,prefabSpike,prefabEnemy;
    public Sprite w1, w2, w3;
    public Sprite sp1, sp2, sp3;
    public static  bool canGo,destroy;
    public static bool generate;
    public static int level=0;
    List<GameObject> clones = new List<GameObject>();
    static List<GameObject> enemies = new List<GameObject>();
    public static void deleteEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
    public static int getLevel()
    {
        return level;
    }
    public static bool returnCanGo()
    {
        return canGo;
    }
    Sprite getSpF()
    {
        int rNum = Random.Range(1, 4);
        Debug.Log(rNum);
        switch (rNum)
        {
            case 1:
                return b1;
            case 2:
                return b2;
            case 3:
                return b3;
            default:
                return b1;
        }
    }
    public static void changeDestroy()
    {
        destroy = true;
    }
    Sprite getSpSp()
    {
        int rNum = Random.Range(1, 4);
        switch (rNum)
        {
            case 1:
                return sp1;
            case 2:
                return sp2;
            case 3:
                return sp3;
            default:
                return sp1;
        }
    }
    Sprite getSpW()
    {
        int rNum = Random.Range(1, 4);
        Debug.Log(rNum);
        switch (rNum)
        {
            case 1:
                return w1;
            case 2:
                return w2;
            case 3:
                return w3;
            default:
                return w1;
        }
    }
    Sprite getSpEnemy()
    {
        int rNum = Random.Range(1, 4);
        Debug.Log(rNum);
        switch (rNum)
        {
            case 1:
                return e1;
            case 2:
                return e2;
            case 3:
                return e3;
            default:
                return e1;
        }
    }
    private void destroyLevel()
    {
        bar.SetActive(false);
        state.SetActive(false);
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i]);
        }
        clones.Clear();
        for(int i = 1;i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
        }

        enemies.Clear();
    }
    IEnumerator createlevel()
    {
        moveCam movecam = GetComponent<moveCam>();
        movecam.move();
        yield return new WaitForSeconds(3f);
        enemies.Insert(0, mainEnemy);
        
        

       
        level++;
        enemies[0].SetActive(true);
        attack.setAttackSpeed(level / 10);
        
        if ((live.getHP() + 10) >= 100){
            live.changeHP(100-live.getHP());
        }
        else
        {
            live.changeHP(10);
        }
        for (int i = 0; i < 10; i++)
        {

            for (int j = 0; j < 19; j++)
            {
               if(enemies.Count < Random.Range(1,4))
                {
                    sprEnemy.sprite = getSpEnemy();
                    var en = Instantiate(prefabEnemy, new Vector2(Random.Range(-5f, 4.5f), Random.Range(-2f, 2f)), Quaternion.identity);
                    enemies.Add((en as Transform).gameObject);
                }
                    if (Random.Range(1, (int)(80-(level*0.7))) == 3)
                    {
                        sprEnemy.sprite = getSpEnemy();
                        var en = Instantiate(prefabEnemy, new Vector2(Random.Range(-5f, 4.5f),  Random.Range(-2f, 2f)), Quaternion.identity);
                        enemies.Add((en as Transform).gameObject);

                    }
                
                if ((i == 3 && j == 0) || (i == 4 && j == 0) || (i == 5 && j == 0) || (i == 6 && j == 0))
                {
                    var d = Instantiate(prefabDoor, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                    clones.Add((d as Transform).gameObject);
                }
                else if ((i == 3 && j == 18) || (i == 4 && j == 18) || (i == 5 && j == 18) || (i == 6 && j == 18))
                {
                    var d = Instantiate(prefabDoor, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                    clones.Add((d as Transform).gameObject);
                }
                else if ((i == 0 && j == 7) || (i == 0 && j == 8) || (i == 0 && j == 9) || (i == 0 && j == 10) || (i == 0 && j == 11))
                {
                    var d = Instantiate(prefabDoor, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                    clones.Add((d as Transform).gameObject);
                }
                else if ((i == 9 && j == 7) || (i == 9 && j == 8) || (i == 9 && j == 9) || (i == 9 && j == 10) || (i == 9 && j == 11))
                {
                    var d = Instantiate(prefabDoor, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                    clones.Add((d as Transform).gameObject);
                }
                else
                {
                    if (i == 0 || j == 0 || i == 9 || j == 18)
                    {

                        yield return new WaitForSeconds(0.0001f);
                        //wall = Instantiate(wall, new Vector3(-6f + j * 0.64f, -3f + i * 0.64f, 0f), Quaternion.identity);
                        var w = Instantiate(prefabWall, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                        clones.Add((w as Transform).gameObject);
                        sprWall.sprite = getSpW();


                    }
                    else
                    {
                        
                        yield return new WaitForSeconds(0.0001f);
                        if (Random.Range(1, 30) == 5)
                        {
                            sprSpike.sprite = getSpSp();
                            var sp = Instantiate(prefabSpike, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                            
                            clones.Add((sp as Transform).gameObject);
                            
                        }
                       
                        // floor = Instantiate(floor, new Vector3(-6f + j * 0.64f, -3f + i * 0.64f,0f), Quaternion.identity);
                        var f = Instantiate(prefabFloor, new Vector2(-6f + j * 0.64f, -3f + i * 0.64f), Quaternion.identity);
                        clones.Add((f as Transform).gameObject);
                        sprFloor.sprite = getSpF();

                    }
                }
    
            } 
        }
        moveCharacter.setMove(true);
        enemies[0].SetActive(false);
        bar.SetActive(true);
        state.SetActive(true);
    }



    void Start()
    {
        mainEnemy = GameObject.FindGameObjectWithTag("enemy");
        destroyLevel();
        bar.SetActive(false);
        state.SetActive(false);
        
        generate = true;
        destroy = false;
        canGo = false;
    }
    
    void Update()
    {
        if(enemies.Count == 1)
        {
            canGo = true;
            var doors = GameObject.FindGameObjectsWithTag("Finish");
            foreach (var i in doors)
            {
                i.GetComponent<SpriteRenderer>().sprite = dopened;
            }
        }
        else
        {

            var doors = GameObject.FindGameObjectsWithTag("Finish");
            foreach (var i in doors)
            {
                i.GetComponent<SpriteRenderer>().sprite = dclosed;
            }
            canGo = false;
        }
        var fen = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log(enemies.Count);
        if (generate)
        {
            
            StartCoroutine(createlevel());
            
            generate = false;
        }
        
        if (destroy)
        {
            moveCharacter.setMove(false);
            destroyLevel();
            destroy = false;
            generate = true;
        }
    }
    
   
}
