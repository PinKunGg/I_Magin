using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScene4 : MonoBehaviour
{
    public Player playerscript;

    // Start is called before the first frame update
    void Start()
    {
        playerscript.sceneC = 4;
        playerscript.esc = true;
        playerscript.PausePlayer(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
