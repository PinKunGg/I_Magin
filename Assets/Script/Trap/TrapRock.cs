using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRock : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(Vector3.down * 10f * Time.deltaTime);
        //transform.Translate(new Vector3(0,-100,0)  * Time.deltaTime);
    }
}
