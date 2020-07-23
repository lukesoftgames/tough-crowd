using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Context
{
    private static Context instance = null;
    public bool trainArrived = false;
    public List<Vector2> trainBoardingPoints = new List<Vector2>();
    public static Context GetInstance()
    {
        if (instance == null)
        {
            instance = new Context();
        }
        return instance;
    }

  

}
