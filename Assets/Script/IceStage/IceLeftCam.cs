using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLeftCam : MonoBehaviour
{
    public Camera cam;
    public Player player;

    public bool IceLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftCam();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.ChangeCam = true;
            IceLeft = true;
        }
    }

    void LeftCam()
    {
        if (IceLeft == true)
        {
            cam.transform.position = new Vector3(player.transform.position.x - 8f, player.transform.position.y + 4f, player.transform.position.z - 15f);
        }
    }
}
