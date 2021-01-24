using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCaveCam : MonoBehaviour
{
    public Camera MainCam;
    public Camera IceCaveCamG;
    public GameObject DirecLight;

    // Start is called before the first frame update
    void Start()
    {
        IceCaveCamG.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MainCam.gameObject.SetActive(false);
            IceCaveCamG.gameObject.SetActive(true);
            //DirecLight.transform.Rotate(600, 0, 0, Space.Self);
            //DirecLight.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
