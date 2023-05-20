using UnityEngine;
using TMPro;

public class DeadZone : MonoBehaviour
{
    public float baseHP;
    public TMP_Text textHP;
    private void Start()
    {
        Loadtext();
    }
    void Loadtext()
    {
        textHP.text = baseHP + "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            baseHP -= other.gameObject.GetComponent<BaseMob>().damage;
            Loadtext();

            if (baseHP <= 0)
            {
                baseHP = 0;
                Loadtext();
                Debug.LogError("You are lose");
            }
            Destroy(other.gameObject);
        }
    }
}
