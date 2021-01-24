using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceKey_Final : MonoBehaviour
{

    Rigidbody rb;

    float RotateTime = 100f;

    public GameObject cube;

    public IceKey_Scene_Final icekeysceneF;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(Vector3.up * 100 * Time.deltaTime);

        transform.RotateAround(cube.transform.position, Vector3.up, 100 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            icekeysceneF.IceKeyShow();
        }
    }
}
