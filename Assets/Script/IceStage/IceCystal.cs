using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCystal : MonoBehaviour
{

    public float min;
    public float max;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= min)
        {
            speed = -1.5f;
        }
        else if (transform.position.y <= max)
        {
            speed = 1.5f;
        }

        this.transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        this.transform.RotateAround(transform.position, Vector3.up, 70 * Time.deltaTime);
    }
}
