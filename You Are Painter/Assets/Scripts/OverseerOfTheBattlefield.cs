using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverseerOfTheBattlefield
{
    public static List<Monster> allTheEnemiesStillAlive = new List<Monster>();

    public static PainterInBattle painter;

    public static void setMonsterList(List<Monster> allTheEnemies){
        allTheEnemiesStillAlive = allTheEnemies;
    }

    public static void setPainter(PainterInBattle theplayer){
        painter = theplayer;
    }

    public static void hitEnemyWithBrush(Vector3 hitLocation){
        foreach(Monster enemy in allTheEnemiesStillAlive){
            if(Mathf.RoundToInt(hitLocation.x) == Mathf.RoundToInt(enemy.transform.position.x) && Mathf.RoundToInt(hitLocation.z) == Mathf.RoundToInt(enemy.transform.position.z)){
                enemy.decreaseHP(painter.getAtk());
                if(enemy.getHP() <= 0){
                    enemy.gameObject.SetActive(false);
                }
            }
        }
    }
}
