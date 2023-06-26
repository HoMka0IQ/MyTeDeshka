using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public GameObject prefab;
    private void Start()
    {
        Generator();
    }
    public void Generator()
    {
        for (int i = 0; i < mapHeight; i++)
        {
            for (int t = 0; t < mapWidth; t++)
            {
                GameObject mapPoint = Instantiate(prefab, new Vector3(transform.position.x + i * 3, 0.01f , transform.position.z + t * 3), Quaternion.identity);
                mapPoint.transform.SetParent(gameObject.transform);
            }
        }
    }
}
