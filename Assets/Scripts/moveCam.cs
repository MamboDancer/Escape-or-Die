using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    public void move()
    {
        StartCoroutine(moveCamera());
    }
    IEnumerator moveCamera()
    {
        for(float i = 0; i < 16; i=i+0.2f)
        {
            transform.position = new Vector3(i, 0f,0f);
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = -16; i <= 0; i = i + 0.2f)
        {
            transform.position = new Vector3(i, 0f, -5f);
            
            yield return new WaitForSeconds(0.01f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
