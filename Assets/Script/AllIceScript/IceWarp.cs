using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceWarp : MonoBehaviour
{
    public LoadingScene loadingS;
    public GameObject WarpNotReady;
    public int icekeyscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        WarpNotReady.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IceKeyCheck(int icekeypoint)
    {
        icekeyscore += icekeypoint;

        print(icekeyscore);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && icekeyscore == 1)
        {
            loadingS.LoadLevel(5);
            print("Warp to scene level 4");
        }

        else if (collision.gameObject.tag == "Player" && icekeyscore != 1)
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
