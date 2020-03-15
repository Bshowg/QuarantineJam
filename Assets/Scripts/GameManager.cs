using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool[] objectives;
    private bool ending;

    void Awake()
    {
        SetUpSingleton();
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i] = false;
        }
        ending = false;
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void CompleteObjective(int objectiveNumber)
    {
        if (!objectives[objectiveNumber])
        {
            objectives[objectiveNumber] = true;
            if (AllCompleted())
            {
                ending = true;
            }
            FindObjectOfType<SpawnCrowd>().UpdateMax(50);
        }
    }

    private bool AllCompleted()
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (!objectives[i]) return false;
        }
        return true;
    }

    public bool IsEnding()
    {
        return ending;
    }
}
