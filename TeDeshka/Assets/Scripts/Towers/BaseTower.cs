using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTower : MonoBehaviour
{
    protected SphereCollider DetectionColl;


    public List<GameObject> AllEnemyInRange;

    public float CDAttack;
    float _CDAttack = 0;
    
    public int Damage;

    public MobState.State state;
    public BaseTower()
    {
        CDAttack = 2;
        Damage = 5;
    }
    private void Start()
    {
        DetectionColl = transform.root.GetChild(0).GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (_CDAttack <= 0)
        {
            if (AllEnemyInRange.Count > 0)
            {
                for (int i = 0; i < AllEnemyInRange.Count; i++)
                {
                    if (AllEnemyInRange[i] == null)
                        AllEnemyInRange.Remove(AllEnemyInRange[i]);
                }
                Shoot();
                _CDAttack = CDAttack;
            }
        }
        else
        {
            _CDAttack -= Time.deltaTime;
        }
    }
    public abstract void Shoot();



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            AllEnemyInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            AllEnemyInRange.Remove(other.gameObject);
        }
    }
}
