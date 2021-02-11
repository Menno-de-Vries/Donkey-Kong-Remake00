using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Float
    private float amountOfPoints = 0;

    private void Update()
    {
        print(amountOfPoints);
    }

    public float Scoring(float score)
    {
        return amountOfPoints += score;
    }

}
