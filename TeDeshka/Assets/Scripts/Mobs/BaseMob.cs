using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseMob : MonoBehaviour
{
    public float movementSpeed;
    public int damage;
    [Range(0,99)]
    public float armor;
    public float HP;
    TMP_Text HPText;

    
    Transform[] RoadPosition;
    int pointsLeft;
    public BaseMob()
    {
        movementSpeed = 10;
        damage = 1;
        HP = 10;
    }
    void Start()
    {
        GameObject textObj = new GameObject("3D Text");
        HPText = textObj.AddComponent<TextMeshPro>();
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(0, 1.5f, 0);
        textObj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        HPText.fontSize = 41;
        HPText.fontStyle = FontStyles.Bold;
        HPText.alignment = TextAlignmentOptions.Center;

        LoadHPText();
    }

    void Update()
    {
        Movement();
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

    public void LoadHPText()
    {
        HPText.text = HP + "";
    }


}
