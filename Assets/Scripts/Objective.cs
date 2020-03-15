using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private bool done = false;

    public void Interaction()
    {
        if (!done)
        {
            print("Interact");
            GameManager gm = FindObjectOfType<GameManager>();
            gm.CompleteObjective();
            if (gm.IsEnding())
            {
                //TODO
            }
            done = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

    }
}
