using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlateCollider : MonoBehaviour
{
    public GameObject Player;
    public IcePlate iceplate;

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
        if (other.gameObject.tag == "Player" && iceplate.Down == false)
        {
            Invoke("PlateCUp", 1f);
            Invoke("PlateCStay", 2f);
        }

        if (other.gameObject.tag == "Player" && iceplate.Up == false)
        {
            Invoke("PlateCDown", 1f);
            Invoke("PlateCStay", 2f);
        }
    }

    public void PlateCUp()
    {
        iceplate.PlateUp();
    }

    public void PlateCDown()
    {
        iceplate.PlateDown();
    }

    public void PlateCStay()
    {
        iceplate.PlateStay();
    }
}
