using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTawer : BaseTower
{
    public GameObject Tower;
    BaseMob target;

    public override void Shoot()
    {
        base.Shoot();

        if (hitColliders.Length <= 0)
            return;
        //система атакування моба який зайшов перший (працює не правильно)


        if(target == null)
            target = hitColliders[0].GetComponent<BaseMob>();

        if (Vector3.Distance(target.transform.position, transform.position) > DetectionColl.radius)
        {
            target = null;
            Shoot();
            return;
        }
        target.TakeDamage(Damage, state);

    }
    private void Update()
    {
        if (target != null && Vector3.Distance(target.transform.position, transform.position) < DetectionColl.radius)
            Tower.transform.LookAt(target.gameObject.transform);
    }

}
