using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public Transform[] RoadPositions;
    public GameObject StandartOgre;

    public float CDSpawn = 4;

    public Material PathMat;
    void Start()
    {
        StartCoroutine(CDSpawnEnemy());
        
    }

    IEnumerator CDSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(CDSpawn);
            GameObject enemy = Instantiate(StandartOgre, new Vector3(RoadPositions[0].position.x, StandartOgre.transform.localScale.y , RoadPositions[0].position.z), Quaternion.identity);
            enemy.GetComponent<BaseMob>().SetPath(RoadPositions);
        }
    }
   

    void OnDrawGizmos()
    {


        for (int i = 0; i < RoadPositions.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(RoadPositions[i].position, 0.3f);
            if (i + 1 < RoadPositions.Length)
                Gizmos.DrawLine(RoadPositions[i].position, RoadPositions[i + 1].position);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(RoadPositions[0].position, 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(RoadPositions[0].position, RoadPositions[0].position);
    }


}
