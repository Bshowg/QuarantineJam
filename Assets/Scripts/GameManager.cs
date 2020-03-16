using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    [SerializeField] private string[] names;
    [SerializeField] private bool[] objectives;
    private bool ending;
    [SerializeField]
    private SceneChanger sc;

    void Awake(){
        sc.gameObject.SetActive(false);
        SetUpSingleton();
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i] = false;
        }
        ending = false;
    }

    private void Start()
    {
        if (objectives.Length == 0)
        {
            sc.gameObject.SetActive(false);
        }
    }
    private void SetUpSingleton(){
        if (FindObjectsOfType(GetType()).Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void CompleteObjective(int objectiveNumber){
        if (!objectives[objectiveNumber]){
            objectives[objectiveNumber] = true;
            if (AllCompleted())
            {
                ending = true;
                sc.gameObject.SetActive(true);
            }
            FindObjectOfType<SpawnCrowd>().UpdateMax(50);
            FindObjectOfType<GoalInterfaceManager>().updateObjectives(objectiveNumber);
        }
    }

    public string[] GetNames(){
        return names;
    }

    public bool[] GetObjectives(){
        return objectives;
    }

    private bool AllCompleted(){
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
