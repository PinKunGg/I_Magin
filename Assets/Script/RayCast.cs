using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    bool RayCastTF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray TestRay = new Ray(transform.position, Vector3.left);

        Debug.DrawRay(transform.position, Vector3.left * 10);

        if (!RayCastTF)
        {
            print("WTF MAN-1");
            if (Physics.Raycast(TestRay,out hit, 10))
            {
                print("WTF MAN-2");
                if (hit.collider.tag == "Player")
                {
                    print("WTF MAN-3");
                    TestRayM();
                }
            }
        }
    }

    void TestRayM()
    {
        RayCastTF = true;
        print("WTF MAN");
    }
}
