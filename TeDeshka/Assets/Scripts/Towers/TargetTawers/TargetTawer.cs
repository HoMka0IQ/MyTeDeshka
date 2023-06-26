using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTawer : BaseTower
{
    public GameObject Tower;
    public BaseMob target;

    public override void Shoot()
    {

        if(target == null)
        {
            // Знаходимо найменшу дистанцію
            float minDistance = Mathf.Infinity;
            GameObject closestEnemy = null;
            foreach (GameObject enemy in AllEnemyInRange)
            {
                if (enemy == null)
                    continue;

                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }
            if (closestEnemy == null)
                return;
            target = closestEnemy.GetComponent<BaseMob>();
        }
        target.TakeDamage(Damage, state);

    }

    private void Update()
    {
        if(target != null)
            transform.LookAt(target.transform);
    }
}
