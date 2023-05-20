using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTawer : BaseTower
{
    SphereCollider DetectionColl;
    public Collider[] hitColliders;
    public LayerMask EnemyLayer;

    public GameObject Tower;
    private void Start()
    {
        StartCoroutine(CDShoot());
        DetectionColl = transform.root.GetChild(0).GetComponent<SphereCollider>();
    }
    public void Shoot()
    {
        //знаходження мобів в радіусі"DetectionColl.radius"
        hitColliders = Physics.OverlapSphere(transform.position, DetectionColl.radius, EnemyLayer);

        if (hitColliders.Length <= 0)
            return;

        //система атакування мобів які йдуть в радіусі бачення тавера
        for (int i = 0; i < hitColliders.Length; i++)
            hitColliders[i].GetComponent<BaseMob>().TakeDamage(Damage);
    }


    IEnumerator CDShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(CDAttack);
            Shoot();
        }
    }
}
