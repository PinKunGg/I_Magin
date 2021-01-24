using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderKeyFinal : MonoBehaviour
{

    Rigidbody rb;

    float RotateTime = 100f;

    public GameObject cube;

    public ThunderKey_SceneFinal thunderkeyscene;

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

            thunderkeyscene.ThunderKeyShow();
        }
    }
}
