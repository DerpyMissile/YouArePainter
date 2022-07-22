using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] GameObject painter;
    [SerializeField] GameObject blueDoor;

    void checkBlueDoor(){
        if(Mathf.RoundToInt(painter.transform.position.x) == Mathf.RoundToInt(blueDoor.transform.position.x) && Mathf.Abs(Input.GetAxis("Vertical")) > 0){
            Debug.Log("Door opens");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBlueDoor();
    }
}
