using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogIceBoss : MonoBehaviour
{
    public TextMeshProUGUI TextIceBoss;
    public GameObject continuebut;
    public string[] sentences;
    private int index;
    private int count = 1;
    public float typespeed;

    public IceBossCinematic icebosscinematic;

    // Start is called before the first frame update
    void Start()
    {
        TextIceBoss.text = "";
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (TextIceBoss.text == sentences[index])
        {
            continuebut.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            TextIceBoss.text += letter;
            yield return new WaitForSeconds(typespeed);
        }
    }

    public void NextText()
    {
        continuebut.SetActive(false);
        count++;

        if (count == 6)
        {
            icebosscinematic.DisCinematic();
        }
        if (index < sentences.Length - 1)
        {
            index++;
            TextIceBoss.text = "";
            StartCoroutine(Type());
        }
        else
        {
            TextIceBoss.text = "";
            continuebut.SetActive(false);
        }
    }
}
