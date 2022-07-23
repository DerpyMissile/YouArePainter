using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] Rigidbody platform;
    [SerializeField] Rigidbody painter;

    IEnumerator startGame(){
        yield return new WaitForSeconds(3.0f);
        if(platform.position.y <= -4){
            platform.velocity = new Vector3(0, 3, 0);
            yield return new WaitForSeconds(3.0f);
        }
        platform.velocity = new Vector3(0,0,0);
        platform.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; 
        painter.gameObject.SetActive(true);
        yield break;
    }

    IEnumerator actuallyStartGame(){
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("TextScene", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        PlayerPrefs.SetInt("UnitySelectMonitor", 2);
        SceneManager.UnloadSceneAsync(currentScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        painter.gameObject.SetActive(false);
        platform.transform.position = new Vector3(platform.transform.position.x, -12, platform.transform.position.z);
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
