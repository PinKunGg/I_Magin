using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindKey_SceneFinal : MonoBehaviour
{

    public IceBoss_BigMage bigicemage;

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

        bigicemage.SkillSet++;
    }
}
