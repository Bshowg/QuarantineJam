using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats: MonoBehaviour 
{
    public Dictionary<StatsEnum, float> stats;
    public Dictionary<StatsEnum, float> baseStats;
    private Dictionary<StatsEnum, float> actualStats;


    [SerializeField]
    float startHP=10;
    [SerializeField]
    float startMP=5;

    void Awake()
    {   
        baseStats= new Dictionary<StatsEnum, float>();
        baseStats.Add(StatsEnum.HP, startHP);
        baseStats.Add(StatsEnum.MP, startMP);
        baseStats.Add(StatsEnum.LVL, 1);
        baseStats.Add(StatsEnum.EXP, 0);

        stats = new Dictionary<StatsEnum,float>();
        stats.Add(StatsEnum.HP,startHP );
        stats.Add(StatsEnum.MP,startMP);
        stats.Add(StatsEnum.LVL, 1);
        stats.Add(StatsEnum.EXP, 0);

        actualStats = new Dictionary<StatsEnum, float>();
        actualStats.Add(StatsEnum.HP, startHP);
        actualStats.Add(StatsEnum.MP, startMP); 
    }

    public void statsMod(StatsEnum st,float amount) => stats[st] += amount;

    public void damage(StatsEnum st, float amount) {
        actualStats[st] -= amount;
        if (actualStats[st] > stats[st]) actualStats[st] = stats[st];
    }

    public float this[StatsEnum c] {
        get { return stats[c]; }
        set { }
    }

    private void Update()
    {
        if (actualStats[StatsEnum.HP] <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
