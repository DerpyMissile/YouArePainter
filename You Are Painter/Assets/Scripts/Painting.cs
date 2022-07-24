using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] private Rigidbody painter;
    [SerializeField] private GameObject paintSubjects;
    [SerializeField] private GameObject inkblob;
    public Vector3 hitspace;
    public Vector3 worldspace;

    void checkIfHitUsingBrush(){
        if(Input.GetMouseButtonDown(0)){
            Instantiate(inkblob, hitspace, Quaternion.identity);
            OverseerOfTheBattlefield.hitEnemyWithBrush(hitspace);
        }
    }

    void checkIfPaintUsingBrush(){
        if(Input.GetMouseButtonDown(1)){

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        paintSubjects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.mousePosition.x > Mathf.RoundToInt(painter.transform.position.x) && Input.mousePosition.z > Mathf.RoundToInt(painter.transform.position.z)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) + 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)+1);
        // }else if(Input.mousePosition.x > Mathf.RoundToInt(painter.transform.position.x) && Input.mousePosition.z < Mathf.RoundToInt(painter.transform.position.z)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) + 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)-1);
        // }else if(Input.mousePosition.x < Mathf.RoundToInt(painter.transform.position.x) && Input.mousePosition.z > Mathf.RoundToInt(painter.transform.position.z)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) - 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)+1);
        // }else if(Input.mousePosition.x < Mathf.RoundToInt(painter.transform.position.x) && Input.mousePosition.z < Mathf.RoundToInt(painter.transform.position.z)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) - 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)-1);
        // }else if(Input.mousePosition.x < Mathf.RoundToInt(painter.transform.position.x)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) - 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z));
        // }else if(Input.mousePosition.x > Mathf.RoundToInt(painter.transform.position.x)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) + 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z));
        // }else if(Input.mousePosition.z < Mathf.RoundToInt(painter.transform.position.z)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x), painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)-1);
        // }else if(Input.mousePosition.z > Mathf.RoundToInt(painter.transform.position.z)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x), painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)+1);
        // }else{
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x), painter.transform.position.y+1, Mathf.RoundToInt(painter.transform.position.z));
        // }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*10, Color.red);
        if(Physics.Raycast(ray, out RaycastHit hitData)){
            worldspace = hitData.point;
        }

        // if(Mathf.RoundToInt(worldspace.x) > Mathf.RoundToInt(painter.transform.position.x)){
        //     hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x)+1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z));
        // }
        if(Mathf.RoundToInt(worldspace.x) > Mathf.RoundToInt(painter.transform.position.x) && Mathf.RoundToInt(worldspace.z) > Mathf.RoundToInt(painter.transform.position.z)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) + 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)+1);
        }else if(Mathf.RoundToInt(worldspace.x) > Mathf.RoundToInt(painter.transform.position.x) && Mathf.RoundToInt(worldspace.z) < Mathf.RoundToInt(painter.transform.position.z)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) + 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)-1);
        }else if(Mathf.RoundToInt(worldspace.x) < Mathf.RoundToInt(painter.transform.position.x) && Mathf.RoundToInt(worldspace.z) > Mathf.RoundToInt(painter.transform.position.z)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) - 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)+1);
        }else if(Mathf.RoundToInt(worldspace.x) < Mathf.RoundToInt(painter.transform.position.x) && Mathf.RoundToInt(worldspace.z) < Mathf.RoundToInt(painter.transform.position.z)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) - 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)-1);
        }else if(Mathf.RoundToInt(worldspace.x) < Mathf.RoundToInt(painter.transform.position.x)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) - 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z));
        }else if(Mathf.RoundToInt(worldspace.x) > Mathf.RoundToInt(painter.transform.position.x)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x) + 1, painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z));
        }else if(Mathf.RoundToInt(worldspace.z) < Mathf.RoundToInt(painter.transform.position.z)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x), painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)-1);
        }else if(Mathf.RoundToInt(worldspace.z) > Mathf.RoundToInt(painter.transform.position.z)){
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x), painter.transform.position.y, Mathf.RoundToInt(painter.transform.position.z)+1);
        }else{
            hitspace = new Vector3(Mathf.RoundToInt(painter.transform.position.x), painter.transform.position.y+1, Mathf.RoundToInt(painter.transform.position.z));
        }

        checkIfHitUsingBrush();
        checkIfPaintUsingBrush();
    }
}
