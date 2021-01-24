using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindWarp : MonoBehaviour
{
    public LoadingScene loadingS;
    public GameObject WarpNotReady;
    public int windkeyscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        WarpNotReady.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WindKeyCheck(int windkeypoint)
    {
        windkeyscore += windkeypoint;

        print(windkeyscore);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && windkeyscore == 1)
        {
            loadingS.LoadLevel(3);
            print("Warp to scene level 2");
        }

        else if (collision.gameObject.tag == "Player" && windkeyscore != 1)
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
