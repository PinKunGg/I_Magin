using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{

    public GameObject loadingscene;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynScene(sceneIndex));
    }

    public IEnumerator LoadAsynScene(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        operation.allowSceneActivation = false;

        loadingscene.gameObject.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Loading: " + (progress * 100).ToString("n2") + "%");

            text.text = ((progress * 100).ToString("n2") + "%");
            slider.value = progress;

            if (progress == 1f)
            {
                print("COMPLETE");
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

}
