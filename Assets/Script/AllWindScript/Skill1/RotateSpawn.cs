using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpawn : MonoBehaviour
{

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
