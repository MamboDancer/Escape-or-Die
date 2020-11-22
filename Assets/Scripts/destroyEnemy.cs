using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MechnicControler hp = GetComponent<MechnicControler>();
        if (collision.gameObject.name == "swing")
        {
            if(hp.getHp()<= 0)
            {
                Destroy(gameObject);
                generateLevel.deleteEnemy(gameObject);
            }
            else
            {
                hp.substractHp(1f);
               
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
