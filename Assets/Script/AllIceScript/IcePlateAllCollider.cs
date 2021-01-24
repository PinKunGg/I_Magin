using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlateAllCollider : MonoBehaviour
{
    public GameObject Player;
    public IcePlateAll iceplateall;
    public int firsttime = 0;

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
        if (firsttime == 1)
        {
            firsttime++;
        }
        if (other.gameObject.tag == "Player" && iceplateall.Down == false && firsttime >= 2)
        {
            Invoke("PlateCUp", 1f);
            Invoke("PlateCStay", 2f);
        }
        if (other.gameObject.tag == "Player" && iceplateall.Up == false && firsttime >= 2)
        {
            Invoke("PlateCDown", 1f);
            Invoke("PlateCStay", 2f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && firsttime == 0)
        {
            firsttime = 1;
        }
    }

    public void PlateCUp()
    {
        iceplateall.PlateUp();
    }

    public void PlateCDown()
    {
        iceplateall.PlateDown();
    }

    public void PlateCStay()
    {
        iceplateall.PlateStay();
    }
}
