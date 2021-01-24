using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlate : MonoBehaviour
{
    public GameObject Player;
    public Animator iceplate;
    public bool Up = false;
    public bool Down = false;
    public bool Stay = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        iceplate.SetBool("Down", Down);
        iceplate.SetBool("Up", Up);
        iceplate.SetBool("Stay", Stay);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == Player)
        {
            Player.transform.parent = this.transform;
        }

        if (other.gameObject.tag == "Player" && Down == false)
        {
            Invoke("PlateUp", 1f);
            Invoke("PlateStay", 2f);
        }

        if (other.gameObject.tag == "Player" && Up == false)
        {
            Invoke("PlateDown", 1f);
            Invoke("PlateStay", 2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }

    public void PlateStay()
    {
        Stay = true;
        Up = false;
        Down = false;
    }

    public void PlateUp()
    {
        Stay = false;
        Up = true;
    }

    public void PlateDown()
    {
        Stay = false;
        Down = true;
    }
}
