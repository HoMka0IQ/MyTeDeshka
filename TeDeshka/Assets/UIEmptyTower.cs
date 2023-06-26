using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEmptyTower : MonoBehaviour
{
    public GameObject menuPosition;
    public GameObject MainTower;
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        menuPosition.transform.position = mainCamera.WorldToScreenPoint(transform.position);
    }

    public void YesBtn()
    {
        Instantiate(MainTower, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void NoBtn()
    {
        Destroy(gameObject);
    }
}
