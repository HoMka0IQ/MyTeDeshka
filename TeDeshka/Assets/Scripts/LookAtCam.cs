using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    Camera MainCamera;
    void Awake()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Отримуємо вектор напрямку від поточного об'єкта до цільової точки
        Vector3 direction = MainCamera.transform.position - transform.position;

        // Інвертуємо напрямок, помноживши вектор на -1
        Vector3 inverseDirection = -direction;

        // Викликаємо LookAt() з інвертованим напрямком
        transform.LookAt(transform.position + inverseDirection);
    }
}
