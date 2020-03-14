using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int completedObjectives;
    [SerializeField] private int numberOfObjectives;
    private bool ending;

    void Awake()
    {
        SetUpSingleton();
        completedObjectives = 0;
        ending = false;
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void CompleteObjective()
    {
        if (completedObjectives < numberOfObjectives)
        {
            completedObjectives++;
            if (completedObjectives == numberOfObjectives)
            {
                ending = true;
            }
        }
    }

    public int GetCompletedObjectives()
    {
        return completedObjectives;
    }

    public bool isEnding()
    {
        return ending;
    }
}
