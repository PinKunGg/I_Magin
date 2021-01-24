using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2FloorUp : MonoBehaviour
{
    public GameObject TrapRock;

    // Start is called before the first frame update
    void Start()
    {
        TrapRock.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TrapRock.gameObject.SetActive(true);
        }
    }
}
