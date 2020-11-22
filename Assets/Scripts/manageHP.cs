using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageHP : MonoBehaviour
{
    
    // Start is called before the first frame update
    private static float stepPos = 0.05f;
    private static float stepScale = 0.09f;
    void Start()
    {
        
    }
     void blitHP(float v)
    {
        transform.position = new Vector2(v * stepPos-5.35f, -4.12f);
        transform.localScale = new Vector2(v * stepScale, 11f);
    }
    // Update is called once per frame
    void Update()
    {
        blitHP(live.getHP());

    }
    
}
