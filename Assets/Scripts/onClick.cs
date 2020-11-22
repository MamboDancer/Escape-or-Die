using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class onClick : MonoBehaviour
{



    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    { 
        GetComponent<Button>().onClick.AddListener(startGame);
    }
   
    // Update is called once per frame
    void Update()
    {
        

    }
    
}
