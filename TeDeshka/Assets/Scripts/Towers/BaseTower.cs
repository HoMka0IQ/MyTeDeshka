using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    protected SphereCollider DetectionColl;
    protected Collider[] hitColliders;

    public float CDAttack;
    
    public int Damage;

    public MobState.State state;
    public BaseTower()
    {
        CDAttack = 2;
        Damage = 5;
    }
    private void Start()
    {

        StartCoroutine(CDShoot());
        DetectionColl = transform.root.GetChild(0).GetComponent<SphereCollider>();
    }
    public virtual void Shoot()
    {
        //знаходження мобів в радіусі"DetectionColl.radius"
        hitColliders = Physics.OverlapSphere(transform.position, DetectionColl.radius, 64);
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
