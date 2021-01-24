using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderKey_SceneFinal : MonoBehaviour
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

    public void ThunderKeyShow()
    {
        gameObject.SetActive(true);

        bigicemage.SkillSet++;
    }
}
