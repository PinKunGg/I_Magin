using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Player playerscript;
    public LoadingScene loadingS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeM()
    {
        playerscript.PausePlayer(false);
        playerscript.Pause.SetActive(false);
        playerscript.esc = true;
    }

    public void QuitM()
    {
        Application.Quit();
    }

    public void MenuM()
    {
        loadingS.LoadLevel(0);
    }
}
