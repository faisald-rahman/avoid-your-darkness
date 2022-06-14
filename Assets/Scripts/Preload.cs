using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    private Text txt;

    // Start is called before the first frame update
    private void Awake()
    {
        txt = GetComponent<Text>();

        StartCoroutine(LoadAsyncScene());
    }

    private IEnumerator LoadAsyncScene()
    {
        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress * 100;
            txt.text = progress + "%";
            if (progress >= 90)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}