﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] private int objectiveNumber = -1;
    private bool done = false;
    [SerializeField]
    Sprite empty;

    public void Interaction()
    {
        if (!done)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.CompleteObjective(objectiveNumber);
            if (gm.IsEnding())
            {
                //TODO
            }
            done = true;
            this.GetComponent<SpriteRenderer>().sprite = empty;
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

    }
}
