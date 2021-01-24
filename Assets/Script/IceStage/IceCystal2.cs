using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCystal2 : MonoBehaviour
{

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(transform.position, Vector3.up, 70 * Time.deltaTime);
    }
}
