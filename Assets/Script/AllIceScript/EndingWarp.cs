using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingWarp : MonoBehaviour
{
    public LoadingScene loadingS;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            loadingS.LoadLevel(6);
            canvas.SetActive(true);
        }
    }
}
