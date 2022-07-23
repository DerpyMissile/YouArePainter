using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralEventManager
{
    public static int stepsTaken = 0;
    public static int scene = 1;

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
}
