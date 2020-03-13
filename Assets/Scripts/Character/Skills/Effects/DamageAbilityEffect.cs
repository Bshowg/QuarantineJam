using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageAbilityEffect : BaseAbilityEffect{
    public override void apply(GameObject target) {
        int attackStrength = gameObject.GetComponent<Characteristics>()[CharTypes.Strenght];
        int defenderDefence = target.gameObject.GetComponent<Characteristics>()[CharTypes.Strenght];

        int damage = (int)Math.Floor((double)attackStrength - (defenderDefence / 3));
        int variance = (int)Math.Max(1, Math.Floor(damage * .1));
        damage += UnityEngine.Random.Range(-variance, variance);

        target.GetComponent<Stats>().damage(StatsEnum.HP, (float)damage);
    }
}
