﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        Context context = Context.GetInstance();

        context.trainArrived = false;
        context.trainBoardingPoints.Add(new Vector2(-6.15f, -2.12f));
        context.trainBoardingPoints.Add(new Vector2(-6.15f, 1.82f));
        LeanTween.moveY(gameObject, 0f, 2f)
            .setEase(LeanTweenType.easeOutQuad)
            .setDelay(10f)
            .setOnComplete(() =>
            {
                AstarPath.active.Scan();
                context.trainArrived = true;
                LeanTween.moveY(gameObject, -10f, 2f)
                   .setEase(LeanTweenType.easeInQuad)
                   .setDelay(5f)
                   .setOnComplete(() =>
                   {
                       AstarPath.active.Scan();
                       context.trainArrived = false;
                   });
            });
    }


}