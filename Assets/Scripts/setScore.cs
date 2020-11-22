using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;

    void Start()
    {
        score.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        score.text = "Level: " + generateLevel.getLevel();
    }
}
