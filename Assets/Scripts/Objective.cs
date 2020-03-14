using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interaction()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.CompleteObjective();
        if (gm.isEnding())
        {
            //TODO
        }
    }
}
