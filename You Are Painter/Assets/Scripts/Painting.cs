using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] private Rigidbody painter;

    void checkIfHitUsingBrush(){
        
    }

    void checkIfPaintUsingBrush(){

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIfHitUsingBrush();
        checkIfPaintUsingBrush();
    }
}
