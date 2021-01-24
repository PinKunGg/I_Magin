using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThunderBossHp : MonoBehaviour
{
    public TextMeshProUGUI HpText;

    public int HpPoint = 100;

    // Start is called before the first frame update
    void Start()
    {
        HpText.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = "Hp: " + HpPoint;

        Death();
    }

    public void HpCount(int point)
    {
        HpPoint = HpPoint - point;
    }

    void Death()
    {
        if (HpPoint <= 0)
        {
            HpText.text = "Hp: 0";
        }
    }
}
