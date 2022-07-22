using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    [SerializeField] Rigidbody painter;
    float timeHoldButton = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) != 0){
            painter.velocity = new Vector3(Input.GetAxis("Horizontal") * 5.0f, painter.velocity.y, 0);
        }
        if(Mathf.Abs(Input.GetAxis("Vertical")) == 1 && timeHoldButton<1.0f){
            timeHoldButton = timeHoldButton + Time.deltaTime;
            painter.velocity = new Vector3(painter.velocity.x, Input.GetAxis("Vertical") * 5.0f, 0);
        }
        timeHoldButton = 0;
    }
}
