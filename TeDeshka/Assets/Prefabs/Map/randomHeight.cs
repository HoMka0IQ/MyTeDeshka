using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y - 0.1f, transform.position.y + 0.1f), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
