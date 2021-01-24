using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogIceBoss_Stage3 : MonoBehaviour
{

    public TextMeshProUGUI TextIceBoss;
    public GameObject continuebut;
    public string[] sentences;
    private int index2;
    private int count2 = 1;
    public float typespeed;

    public IceBossCinematic icebosscinematic;

    // Start is called before the first frame update
    void Start()
    {
        TextIceBoss.text = "";
        StartCoroutine(Type2());
    }

    // Update is called once per frame
    void Update()
    {
        if (TextIceBoss.text == sentences[index2])
        {
            continuebut.SetActive(true);
        }
    }

    IEnumerator Type2()
    {
        foreach(char letter in sentences[index2].ToCharArray())
        {
            TextIceBoss.text += letter;
            yield return new WaitForSeconds(typespeed);
        }
    }

    public void NextText()
    {
        continuebut.SetActive(false);
        count2++;

        if (count2 == 4)
        {
            icebosscinematic.BeforeMagePurple();
        }
        if (index2 < sentences.Length - 1)
        {
            index2++;
            TextIceBoss.text = "";
            StartCoroutine(Type2());
        }
        else
        {
            TextIceBoss.text = "";
            continuebut.SetActive(false);
        }
    }
}
