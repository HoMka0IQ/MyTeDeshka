using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public float CDAttack;
    
    public int Damage;

    public BaseTower()
    {
        CDAttack = 2;
        Damage = 5;
    }

}
