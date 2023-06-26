using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTawer : BaseTower
{

    public override void Shoot()
    {
        //система атакування мобів які йдуть в радіусі бачення тавера
        for (int i = 0; i < AllEnemyInRange.Count; i++)
        {
            if (AllEnemyInRange[i] != null)
                AllEnemyInRange[i].GetComponent<BaseMob>().TakeDamage(Damage, state);
        }
            
    }



}
