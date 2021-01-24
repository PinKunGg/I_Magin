using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThunderWarp : MonoBehaviour
{
    public LoadingScene loadingS;
    public GameObject WarpNotReady;
    public int thunderkeyscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        WarpNotReady.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThunderKeyCheck(int thunderkeypoint)
    {
        thunderkeyscore += thunderkeypoint;

        print(thunderkeyscore);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && thunderkeyscore == 1)
        {
            loadingS.LoadLevel(4);
            print("Warp to scene level 3");
        }

        else if (collision.gameObject.tag == "Player" && thunderkeyscore != 1)
        {
            WarpNotReady.SetActive(true);
            Invoke("WarpDis", 2f);
            print("Warp Not Ready");
        }
    }

    void WarpDis()
    {
        WarpNotReady.SetActive(false);
    }
}
