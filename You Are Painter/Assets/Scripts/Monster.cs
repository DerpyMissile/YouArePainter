using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int atk = 1;
    protected int range = 1;
    protected int movement = 1;
    protected int hp = 1;
    protected string nature = "neutral";

    void changeHP(int newhp){
        hp = newhp;
    }
    void changerange(int newrange){
        range = newrange;
    }
    void changemovement(int newmovement){
        movement = newmovement;
    }
    
    public int getHP(){
        return hp;
    }
    public int getAtk(){
        return atk;
    }
    public int getMovement(){
        return movement;
    }
    public string getNature(){
        return nature;
    }
    public int getRange(){
        return range;
    }
}
