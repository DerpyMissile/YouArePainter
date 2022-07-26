using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    [SerializeField] GameObject yellowOrb;
    [SerializeField] GameObject blueOrb;
    [SerializeField] List<Monster> enemiesOnTheLeftBuilding = new List<Monster>();
    [SerializeField] List<Monster> enemiesOnTheRightBuilding = new List<Monster>();
    [SerializeField] List<Monster> enemiesOnTheRoad = new List<Monster>();
    [SerializeField] List<Monster> enemiesOnTheBeach = new List<Monster>();
    List<Monster> allMonster = new List<Monster>();
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

    void monsterTime(){
        foreach(Monster enemy in allMonster){
            if(enemy.getHP()>0 && enemy.GetComponent<Renderer>().isVisible){
                string enemyNature = enemy.getNature();
                switch(enemyNature){
                    case "Aggressive":
                        if(Mathf.RoundToInt(enemy.transform.position.x) == Mathf.RoundToInt(thePainter.transform.position.x) && Mathf.RoundToInt(enemy.transform.position.z) < Mathf.RoundToInt(thePainter.transform.position.z)){
                            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z+1);
                        }else if(Mathf.RoundToInt(enemy.transform.position.x) == Mathf.RoundToInt(thePainter.transform.position.x) && Mathf.RoundToInt(enemy.transform.position.z) > Mathf.RoundToInt(thePainter.transform.position.z)){
                            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z-1);
                        }else if(Mathf.RoundToInt(enemy.transform.position.x) > Mathf.RoundToInt(thePainter.transform.position.x)){
                            enemy.transform.position = new Vector3(enemy.transform.position.x-1, enemy.transform.position.y, enemy.transform.position.z);
                        }else{
                            enemy.transform.position = new Vector3(enemy.transform.position.x+1, enemy.transform.position.y, enemy.transform.position.z);
                        }
                        break;
                    case null:
                        break;
                }
            }
        }
    }

    void checkForReals(){
        if(leftClear && rightClear && !yellowOrb.activeInHierarchy){
            yellowOrb.SetActive(true);
        }
        if(beachClear && roadClear && !blueOrb.activeInHierarchy){
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
            StartCoroutine(endLevel());
        }
    }

    IEnumerator endLevel(){
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Overworld", LoadSceneMode.Additive);
        while(!asyncload.isDone){
            yield return null;
        }
        PlayerPrefs.SetInt("UnitySelectMonitor", 2);
        SceneManager.UnloadSceneAsync(currentScene);
    }
    // Start is called before the first frame update
    void Start()
    {
        OverseerOfTheBattlefield.setPainter(thePainter);
        yellowOrb.SetActive(false);
        blueOrb.SetActive(false);
        placeholder1 = GameObject.FindObjectsOfType<Monster>();
        foreach(Monster enemy in placeholder1){
            if(enemy.tag == "Area1"){
                enemiesOnTheLeftBuilding.Add(enemy);
                allMonster.Add(enemy);
            }else if(enemy.tag == "Area2"){
                enemiesOnTheRightBuilding.Add(enemy);
                allMonster.Add(enemy);
            }else if(enemy.tag == "Area3"){
                enemiesOnTheRoad.Add(enemy);
                allMonster.Add(enemy);
            }else{
                enemiesOnTheBeach.Add(enemy);
                allMonster.Add(enemy);
            }
        }
        OverseerOfTheBattlefield.setMonsterList(allMonster);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
            monsterTime();
        }
        checkIfKilled();
        checkIfBumped();
    }
}
