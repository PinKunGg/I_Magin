using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindKey_Scene : MonoBehaviour
{

    public WindWarp windwarp;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WindKeyShow()
    {
        gameObject.SetActive(true);

        windwarp.WindKeyCheck(1);
    }
}
