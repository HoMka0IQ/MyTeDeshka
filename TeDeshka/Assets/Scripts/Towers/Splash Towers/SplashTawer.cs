using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTawer : BaseTower
{

    public GameObject Tower;
    public override void Shoot()
    {
        base.Shoot();

        if (hitColliders.Length <= 0)
            return;

        //система атакування мобів які йдуть в радіусі бачення тавера
        for (int i = 0; i < hitColliders.Length; i++)
            hitColliders[i].GetComponent<BaseMob>().TakeDamage(Damage);
    }



}
