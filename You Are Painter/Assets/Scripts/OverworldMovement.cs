using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldMovement : MonoBehaviour
{
    [SerializeField] Rigidbody painter;
    [SerializeField] Rigidbody greatSage;

    [SerializeField] Text nameText;
    [SerializeField] Text speechText;
    [SerializeField] GameObject leftPerson;
    [SerializeField] GameObject rightPerson;
    float timeHoldButton = 0.0f;
    bool checkIfBumped = false;

    IEnumerator checkIfBump(){
        nameText.transform.parent.position = new Vector3(518, nameText.transform.parent.position.y, nameText.transform.parent.position.z);
        nameText.text = "Great Sage";
        speechText.text = "OWAFJSDILAJSDLA;";
        yield return new WaitForSeconds(3.0f);
        checkIfBumped = false;
        yield return null;
    }

    void onCollisionEnter(){
        checkIfBumped = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkIfBump());
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) != 0){
            painter.velocity = new Vector3(Input.GetAxis("Horizontal") * 5.0f, painter.velocity.y, 0);
        }
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0 && timeHoldButton<1.0f){
            timeHoldButton = timeHoldButton + Time.deltaTime;
            painter.velocity = new Vector3(painter.velocity.x, Input.GetAxis("Vertical") * 8.0f, 0);
        }
        if(Mathf.RoundToInt(painter.velocity.y) == 0){
            timeHoldButton = 0;
        }
    }
}
