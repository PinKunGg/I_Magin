using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hp : MonoBehaviour
{

    public TextMeshProUGUI HpText;
    public GameObject GameOver;

    public int HpPoint = 100;

    bool GodMode = false;

    // Start is called before the first frame update
    void Start()
    {
        HpText = gameObject.GetComponent<TextMeshProUGUI>();
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = "Hp: " +HpPoint;

        Death();

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GodMode == false)
            {
                print("GodMode - Active");
                GodMode = true;
            }

            else if (GodMode == true)
            {
                print("GodMode - DisActive");
                GodMode = false;
            }
        }
    }

    public void HpCount(int point)
    {
        if (GodMode == false)
        {
            HpPoint = HpPoint - point;
        }
    }

    void Death()
    {
        if (HpPoint <= 0)
        {
            HpText.text = "Hp: 0";

            GameOver.gameObject.SetActive(true);
            print("GameOver");
        }
    }
}
