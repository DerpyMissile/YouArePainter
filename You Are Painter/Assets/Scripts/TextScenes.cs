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
                //yield return new WaitForSeconds(3.0f);
                nameText.transform.parent.position = new Vector3(600, nameText.transform.parent.position.y, nameText.transform.parent.position.z);
                nameText.text = "Painter";
                speechText.text = "SORRY CAN'T TALK RIGHT NOW GOTTA ZOOM";
                yield return new WaitForSeconds(3.0f);
                nameText.transform.parent.position = new Vector3(1200, nameText.transform.parent.position.y, nameText.transform.parent.position.z);
                nameText.text = "The Great Sage";
                speechText.text = "What? What are you on about, young one-";
                yield return new WaitForSeconds(3.0f);
                nameText.transform.parent.position = new Vector3(600, nameText.transform.parent.position.y, nameText.transform.parent.position.z);
                nameText.text = "Painter";
                speechText.text = "GAME JAM'S ENDING IN 20 HOURS GOTTA MOVE IT GOTTA GET THE CORE FEATURES IN THAT SHOULD'VE BEEN DONE 2 DAYS AGO";
                yield return new WaitForSeconds(3.0f);
                nameText.transform.parent.position = new Vector3(1200, nameText.transform.parent.position.y, nameText.transform.parent.position.z);
                nameText.text = "The Great Sage";
                speechText.text = "...what?";
                yield return new WaitForSeconds(3.0f);
                nameText.transform.parent.position = new Vector3(600, nameText.transform.parent.position.y, nameText.transform.parent.position.z);
                nameText.text = "Painter";
                speechText.text = "FDAKLFJL;ASFJLSA;JF";
                yield return new WaitForSeconds(1.0f);
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
