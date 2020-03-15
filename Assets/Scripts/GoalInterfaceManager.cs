using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GoalInterfaceManager : MonoBehaviour{
    public GameObject goalbutton;

    public List<GameObject> goals;
    
    void Start(){
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        goals = new List<GameObject>();

        string[] names = gm.GetNames();

        Vector2 startingpos = new Vector2(100, Screen.height-50);


        for (int i = 0; i < names.Length; i++) {
            GameObject newgoal = GameObject.Instantiate(goalbutton) as GameObject;
            newgoal.transform.SetParent(transform);
            newgoal.transform.position = startingpos;

            newgoal.GetComponentInChildren<TextMeshProUGUI>().text = names[i];

            

            goals.Add(newgoal);
            startingpos.y -= 40;
        }
    }


    public void updateObjectives(int i) {
        goals[i].GetComponent<Toggle>().isOn = true;
        goals[i].GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;

    }
}
