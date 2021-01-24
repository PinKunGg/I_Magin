using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderKey_Scene : MonoBehaviour
{

    public ThunderWarp thunderwarp;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThunderKeyShow()
    {
        gameObject.SetActive(true);

        thunderwarp.ThunderKeyCheck(1);
    }
}
