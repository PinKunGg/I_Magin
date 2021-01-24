using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScene3 : MonoBehaviour
{
    public IceWarp icewarp1;
    public Player playerscript;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);

        playerscript.sceneC = 3;

        icewarp1.icekeyscore = 0;
        playerscript.esc = true;
        playerscript.PausePlayer(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
