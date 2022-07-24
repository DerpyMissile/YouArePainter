using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] Rigidbody platform;
    [SerializeField] Rigidbody painter;

    [SerializeField] GameObject you;
    [SerializeField] GameObject are;
    [SerializeField] GameObject painterTheWord;

    [SerializeField] GameObject wasd;
    [SerializeField] GameObject leftMouse;
    [SerializeField] GameObject rightMouse;

    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;

    bool wentThrough = false;

    IEnumerator startGame(){
        yield return new WaitForSeconds(1.0f);
        you.SetActive(true);
        light1.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        are.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        light2.SetActive(true);
        painterTheWord.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        if(platform.position.y <= -4){
            platform.velocity = new Vector3(0, 4.5f, 0);
            yield return new WaitForSeconds(2.0f);
        }
        platform.velocity = new Vector3(0,0,0);
        platform.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 
        wasd.SetActive(true);
        leftMouse.SetActive(true);
        rightMouse.SetActive(true);
        painter.gameObject.SetActive(true);
        yield break;
    }

    IEnumerator actuallyStartGame(){
        yield return new WaitUntil(() => wentThrough);
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("TextScene", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        PlayerPrefs.SetInt("UnitySelectMonitor", 2);
        //managersama.addScene();
        //SceneManager.MoveGameObjectToScene(managersama, SceneManager.GetSceneByName("TextScene"));
        SceneManager.UnloadSceneAsync(currentScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        you.SetActive(false);
        are.SetActive(false);
        painterTheWord.SetActive(false);
        wasd.SetActive(false);
        leftMouse.SetActive(false);
        rightMouse.SetActive(false);
        painter.gameObject.SetActive(false);
        platform.transform.position = new Vector3(platform.transform.position.x, -12, platform.transform.position.z);
        StartCoroutine(startGame());
        StartCoroutine(actuallyStartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if(painter.transform.position.x >= 20){
            wentThrough = true;
        }
    }
}
