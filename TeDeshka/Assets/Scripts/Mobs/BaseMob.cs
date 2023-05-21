using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseMob : MonoBehaviour
{
    float movementSpeed;
    public float MaxMovementSpeed;
    public int damage;
    [Range(0,99)]
    public float armor;
    public float HP;
    public TMP_Text HPText;

    
    Transform[] RoadPosition;
    int pointsLeft;

    float InFire;
    float PereodicTimaInFire;
    public GameObject FireParticle;
    float InFrost;
    public GameObject FrostParticle;
    public BaseMob()
    {
        MaxMovementSpeed = 10;
        damage = 1;
        HP = 10;
    }
    public BaseMob(int damage, float movementSpeed, float armor, float HP)
    {
        this.damage = damage;
        this.movementSpeed = movementSpeed;
        this.armor = armor;
        this.HP = HP;
    }
    void Start()
    {
        LoadHPText();

        movementSpeed = MaxMovementSpeed;
    }

    void Update()
    {
        Movement();

        if (InFire > 0)
        {
            FireParticle.SetActive(true);
            InFire -= Time.deltaTime;
            PereodicTimaInFire += Time.deltaTime;
            if (PereodicTimaInFire >= 1)
            {
                TakeDamage(5,true);
                PereodicTimaInFire = 0;
            }

            if (InFire <= 0)
                FireParticle.SetActive(false);
        }

        if (InFrost > 0)
        {
            FrostParticle.SetActive(true);
            InFrost -= Time.deltaTime;
            movementSpeed = MaxMovementSpeed / 2;
            if (InFrost <= 0)
                movementSpeed = MaxMovementSpeed;

            if (InFrost <= 0)
                FrostParticle.SetActive(false);
        }
    }
    void Movement()
    {
        //захист від посилок коли моб проходить всі точки
        if (RoadPosition.Length <= pointsLeft)
            return;

        //система руху моба до точки, які вказані в масиві "RoadPosition"
        Vector3 LockYPos = new Vector3(RoadPosition[pointsLeft].position.x, transform.localScale.y, RoadPosition[pointsLeft].position.z);
        Vector3 direction = (LockYPos - transform.position).normalized;
        
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
        transform.LookAt(LockYPos);
        //зміна точки до якої йде моб, після того як він дойде до неї
        if (Vector3.Distance(transform.position, LockYPos) < 0.1f)
        {
            pointsLeft++;
        }
    }
    public void SetPath(Transform[] RoadPosition)
    {
        this.RoadPosition = RoadPosition;
        pointsLeft = 0;
    }
    public void TakeDamage(int dmg)
    {
        HP -= dmg - ((dmg * armor) / 100);
        LoadHPText();

        if (HP <= 0)
            Destroy(gameObject);
    }
    public void TakeDamage(int dmg, MobState.State state)
    {
        TakeDamage(dmg);
        switch (state)
        {
            case MobState.State.InFire:
                InFire = 5f;
                break;
            case MobState.State.InFrost:
                InFrost = 5f;
                break;
        }
    }
    public void TakeDamage(int dmg, bool TrueDamage)
    {
        HP -= dmg;
        LoadHPText();

        if (HP <= 0)
            Destroy(gameObject);
    }

    public void LoadHPText()
    {
        HPText.text = HP + "";
    }


}
