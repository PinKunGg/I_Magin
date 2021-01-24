using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public LoadingScene loadingS;
    public GameObject Setting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startbutton()
    {
        loadingS.LoadLevel(1);
    }

    public void settingbutton()
    {
        Setting.SetActive(true);
    }

    public void backbutton()
    {
        Setting.SetActive(false);
    }
}
