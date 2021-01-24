using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRightCam : MonoBehaviour
{
    public Player player;
    public IceLeftCam IceLeftS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.ChangeCam = false;
            IceLeftS.IceLeft = false;
        }
    }
}
