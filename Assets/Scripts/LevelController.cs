using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for levels, shows winLabel or Loselabel
/// </summary>
public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0; //number of attacker
    bool levelTimerFinished = false;


    private void Start()
    {
        if (PlayerStats.GameStart == null) PlayerStats.GameStart = DateTime.Now;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    /// <summary>
    /// Attacker is spawned
    /// </summary>
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    /// <summary>
    /// Attacker is killed
    /// </summary>
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End level now");
            StartCoroutine(HandleWinCondition());
        }

    }
    /// <summary>
    /// In case of win level
    /// </summary>
    /// <returns></returns>
    IEnumerator HandleWinCondition()
    {
        PlayerStats.Level++; //log stats
        winLabel.SetActive(true); //show win label
        GetComponent<AudioSource>().Play(); //play audio
        yield return new WaitForSeconds(waitToLoad); //wait
        FindObjectOfType<LevelLoader>().LoadNextScene(); //load next scene
    }
    /// <summary>
    /// In case of lose
    /// </summary>
    public void HandleLoseCondition()
    {
        Time.timeScale = 0; //handle time -> stop it
        loseLabel.SetActive(true);
    }
    /// <summary>
    /// When Level time is finished
    /// </summary>
    public void LevelTimerFinished()
    {
        Debug.Log("Time is up");

        levelTimerFinished = true;
        StopSpawners();
    }

    /// <summary>
    /// Stops spawing on every lane
    /// </summary>
    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
