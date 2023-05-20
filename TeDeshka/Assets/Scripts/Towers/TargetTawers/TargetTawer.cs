using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTawer : BaseTower
{
    SphereCollider DetectionColl;
    Collider[] hitColliders;
    public LayerMask EnemyLayer;

    public GameObject Tower;
    public BaseMob target;
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
        //система атакування моба який зайшов перший (працює не правильно)
        if(target == null)
            target = hitColliders[hitColliders.Length - 1].GetComponent<BaseMob>();

        target.TakeDamage(Damage);

    }
    private void Update()
    {
        if (target != null)
            Tower.transform.LookAt(hitColliders[hitColliders.Length - 1].transform);

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
