using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverseerOfTheBattlefield
{
    public static bool hitEnemyWithBrush(Vector3 hitLocation, List<Monster> allTheEnemiesStillAlive){
        foreach(Monster enemy in allTheEnemiesStillAlive){
            if(Mathf.RoundToInt(new Vector3(hitLocation.x, 0, hitLocation.z)) == Mathf.RoundToInt(new Vector3(enemy.transform.position.x, 0, enemy.transform.position.z))){
                
            }
        }
    }
}
