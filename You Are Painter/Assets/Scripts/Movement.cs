using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody painter;
    public float timeBetweenMoves = 0.0f;
    public float speedOfMove = 5.0f;
    // Start is called before the first frame update
    void reposition(){
        int newX = Mathf.RoundToInt(painter.position.x);
        //float newY = Mathf.Round(painter.position.y) * 1f;
        int newZ = Mathf.RoundToInt(painter.position.z);
        painter.position = new Vector3(newX, painter.position.y, newZ);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 stopLocation = new Vector3(0,0,0);
        timeBetweenMoves = timeBetweenMoves + Time.fixedDeltaTime;
        if(timeBetweenMoves > 1.0f){
            if(Input.GetKeyDown(KeyCode.W)){
                //painter.position = Vector3.MoveTowards(painter.position, new Vector3(painter.position.x, painter.position.y, painter.position.z+1), (speedOfMove*Time.deltaTime));
                painter.velocity = new Vector3(0, 0, speedOfMove);
                stopLocation = new Vector3(painter.position.x, painter.position.y, painter.position.z+1);
                timeBetweenMoves = 0;
            }
            if(Input.GetKeyDown(KeyCode.A)){
                //painter.position = Vector3.MoveTowards(painter.position, new Vector3(painter.position.x, painter.position.y, painter.position.z+1), (speedOfMove*Time.deltaTime));
                painter.velocity = new Vector3(-speedOfMove, 0, 0);
                stopLocation = new Vector3(painter.position.x-1, painter.position.y, painter.position.z);
                timeBetweenMoves = 0;
            }
            if(Input.GetKeyDown(KeyCode.S)){
                //painter.position = Vector3.MoveTowards(painter.position, new Vector3(painter.position.x, painter.position.y, painter.position.z+1), (speedOfMove*Time.deltaTime));
                painter.velocity = new Vector3(0, 0, -speedOfMove);
                stopLocation = new Vector3(painter.position.x, painter.position.y, painter.position.z-1);
                timeBetweenMoves = 0;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                //painter.position = Vector3.MoveTowards(painter.position, new Vector3(painter.position.x, painter.position.y, painter.position.z+1), (speedOfMove*Time.deltaTime));
                painter.velocity = new Vector3(speedOfMove, 0, 0);
                stopLocation = new Vector3(painter.position.x+1, painter.position.y, painter.position.z);
                timeBetweenMoves = 0;
            }
            if(painter.position == stopLocation){
                painter.velocity = new Vector3(0,0,0);
                reposition();
            }
        }
    }
}
