using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] GameObject yellowOrb;
    [SerializeField] GameObject blueOrb;
    [SerializeField] List<Monster> enemiesOnTheLeftBuilding = new List<Monster>();
    [SerializeField] List<Monster> enemiesOnTheRightBuilding = new List<Monster>();
    [SerializeField] List<Monster> enemiesOnTheRoad = new List<Monster>();
    [SerializeField] List<Monster> enemiesOnTheBeach = new List<Monster>();
    [SerializeField] PainterInBattle thePainter;
    public Monster[] placeholder1;

    bool leftClear = false;
    bool rightClear = false;
    bool roadClear = false;
    bool beachClear = false;

    void checkIfKilled(){
        if(thePainter.getHP() <= 0){
            Debug.Log("You died");
            return;
        }
        foreach (Monster monsterdude in enemiesOnTheLeftBuilding){
            if(monsterdude.getHP() <= 0){

            }else{
                break;
            }
            leftClear = true;
        }
        foreach (Monster monsterdude in enemiesOnTheRightBuilding){
            if(monsterdude.getHP() <= 0){

            }else{
                break;
            }
            rightClear = true;
        }
        foreach (Monster monsterdude in enemiesOnTheRoad){
            if(monsterdude.getHP() <= 0){

            }else{
                break;
            }
            roadClear = true;
        }
        foreach (Monster monsterdude in enemiesOnTheBeach){
            if(monsterdude.getHP() <= 0){

            }else{
                break;
            }
            beachClear = true;
        }
        checkForReals();
    }

    void checkForReals(){
        if(leftClear && rightClear){
            yellowOrb.SetActive(true);
        }
        if(beachClear && roadClear){
            blueOrb.SetActive(true);
        }
    }

    void checkIfBumped(){
        if(Mathf.RoundToInt(thePainter.transform.position.x) == Mathf.RoundToInt(yellowOrb.transform.position.x) && Mathf.RoundToInt(thePainter.transform.position.z) == Mathf.RoundToInt(yellowOrb.transform.position.z)){
            Destroy(yellowOrb);
            GeneralEventManager.addToOrbs("Yellow");
        }
        if(Mathf.RoundToInt(thePainter.transform.position.x) == Mathf.RoundToInt(blueOrb.transform.position.x) && Mathf.RoundToInt(thePainter.transform.position.z) == Mathf.RoundToInt(blueOrb.transform.position.z)){
            Destroy(blueOrb);
            GeneralEventManager.addToOrbs("Blue");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        yellowOrb.SetActive(false);
        blueOrb.SetActive(false);
        placeholder1 = GameObject.FindObjectsOfType<Monster>();
        foreach(Monster enemy in placeholder1){
            if(enemy.tag == "Area1"){
                enemiesOnTheLeftBuilding.Add(enemy);
            }else if(enemy.tag == "Area2"){
                enemiesOnTheRightBuilding.Add(enemy);
            }else if(enemy.tag == "Area3"){
                enemiesOnTheRoad.Add(enemy);
            }else{
                enemiesOnTheBeach.Add(enemy);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkIfKilled();
        checkIfBumped();
    }
}
