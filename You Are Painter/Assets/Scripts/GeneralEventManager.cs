using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralEventManager
{
    public static int stepsTaken = 0;
    public static int scene = 1;
    public static List<string> orbsGotten = new List<string>();
    public static bool actionDone = false;

    public static void addScene(){
        scene++;
    }

    public static int whatScene(){
        return scene;
    }

    public static void addSteps(){
        stepsTaken++;
    }

    public static int howManySteps(){
        return stepsTaken;
    }
    public static void addToOrbs(string whichOrb){
        orbsGotten.Add(whichOrb);
    }

    public static void doAction(){
        actionDone = true;
    }

    public static void noMoreAction(){
        actionDone = false;
    }
}
