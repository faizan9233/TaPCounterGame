using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    public Dictionary<int,string> levelScores = new Dictionary<int,string>();

    // Start is called before the first frame update
    void Start()
    {
        levelScores[1] = "level one";
        levelScores[2] = "level Two";
        Debug.Log(levelScores[1] + levelScores[2]);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
