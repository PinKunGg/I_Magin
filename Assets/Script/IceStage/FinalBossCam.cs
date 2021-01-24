using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossCam : MonoBehaviour
{
    public Camera MainCam;
    public Camera BossCam;

    // Start is called before the first frame update
    void Start()
    {
        BossCam.gameObject.SetActive(false);
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
            BossCam.gameObject.SetActive(true);
        }
    }
}
