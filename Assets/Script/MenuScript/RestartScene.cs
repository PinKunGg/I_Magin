using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{

    public LoadingScene loadingS;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart1()
    {
        loadingS.LoadLevel(2);
        canvas.SetActive(true);
    }

    public void Restart2()
    {
        loadingS.LoadLevel(3);
        canvas.SetActive(true);
    }

    public void Restart3()
    {
        loadingS.LoadLevel(4);
        canvas.SetActive(true);
    }
    public void Restart4()
    {
        loadingS.LoadLevel(5);
        canvas.SetActive(true);
    }
}
