using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int atk = 1;
    private int range = 1;
    private int movement = 1;
    private int hp = 1;
    private string nature = "neutral";
    private int counter = 0;

    public void decreaseHP(int howMuch){
        hp-=howMuch;
    }
    public void changeHP(int newhp){
        hp = newhp;
    }
    public void changerange(int newrange){
        range = newrange;
    }
    public void changemovement(int newmovement){
        movement = newmovement;
    }
    public void changenature(string newnature){
        nature = newnature;
    }
    public void changeCounter(int newcounter){
        counter = newcounter;
    }
    public void decreaseCounter(){
        counter--;
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
    public int getCounter(){
        return counter;
    }
}
