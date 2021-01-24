using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceKey_Scene_Final : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IceKeyShow()
    {
        gameObject.SetActive(true);
    }
}
