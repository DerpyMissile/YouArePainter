using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] GameObject painter;
    [SerializeField] GameObject blueDoor;

    bool touchingBlue = false;

    void checkBlueDoor(){
        if(Mathf.RoundToInt(painter.transform.position.x) == Mathf.RoundToInt(blueDoor.transform.position.x) && Mathf.Abs(Input.GetAxis("Vertical")) > 0){
            touchingBlue = true;
        }
    }

    IEnumerator goThroughBlueDoor(){
        yield return new WaitUntil(() => touchingBlue);
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Level-1", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        PlayerPrefs.SetInt("UnitySelectMonitor", 2);
        SceneManager.UnloadSceneAsync(currentScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(goThroughBlueDoor());
    }

    // Update is called once per frame
    void Update()
    {
        checkBlueDoor();
    }
}
