using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildBTN : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    Camera mainCamera;
    Image Main_Image;
    public GameObject towerEmptyPrefab;
    
    GameObject emptyTower;
    void Start()
    {
        Main_Image = GetComponent<Image>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (emptyTower == null)
            emptyTower = Instantiate(towerEmptyPrefab, Vector3.zero, Quaternion.identity);

        transform.position = eventData.position;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        int selectedLayer = LayerMask.NameToLayer("Map");
        LayerMask layerMask = 1 << selectedLayer;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1500f, layerMask))
        {
 

            emptyTower.transform.position = hit.transform.position;
            Main_Image.color = new Color(Main_Image.color.r, Main_Image.color.g, Main_Image.color.b, 0);
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Main_Image.color = new Color(Main_Image.color.r, Main_Image.color.g, Main_Image.color.b, 255);
        transform.position = transform.parent.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
