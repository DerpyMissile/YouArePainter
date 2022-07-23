using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScenes : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text speechText;

    IEnumerator checkWhatScene(){
        int sceneNumber = GeneralEventManager.whatScene();
        switch(sceneNumber){
            case 1:
                yield return new WaitForSeconds(1.0f);
                nameText.text = "Painter";
                speechText.text = "Ugh...";
                break;
            default:
                break;
        }
        StartCoroutine(actuallyStartGame());
    }

    IEnumerator actuallyStartGame(){
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        PlayerPrefs.SetInt("UnitySelectMonitor", 2);
        SceneManager.UnloadSceneAsync(currentScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkWhatScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
