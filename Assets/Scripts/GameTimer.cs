﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Tracks Game time
/// </summary>
public class GameTimer : MonoBehaviour
{


    [Tooltip("level timer in seconds")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;


    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            //Debug.Log("level timer expired");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }


}
