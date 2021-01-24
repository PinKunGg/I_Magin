using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartDialog : MonoBehaviour
{
    public TextMeshProUGUI TextIceBoss;
    public GameObject continuebut;
    public string[] sentences;
    private int index2;
    public float typespeed;
    int count = 1;

    public LoadingScene loadingS;
    public GameObject canvas1;
    public GameObject canvas;

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
        foreach (char letter in sentences[index2].ToCharArray())
        {
            TextIceBoss.text += letter;
            yield return new WaitForSeconds(typespeed);
        }
    }

    public void NextText()
    {
        continuebut.SetActive(false);
        count++;

        if (count > 5)
        {
            loadingS.LoadLevel(2);
            canvas.SetActive(true);
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
    public void NextText2()
    {
        continuebut.SetActive(false);
        count++;

        if (count > 4)
        {
            canvas.SetActive(false);
            canvas1.SetActive(true);
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
