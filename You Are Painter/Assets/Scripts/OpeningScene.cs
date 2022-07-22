using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] Rigidbody platform;
    [SerializeField] Rigidbody painterForNow;

    IEnumerator startGame(){
        yield return new WaitForSeconds(3.0f);
        while(platform.position.y <= -6){
            platform.velocity = new Vector3(0, 3, 0);
        }
        platform.velocity = new Vector3(0,0,0);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
