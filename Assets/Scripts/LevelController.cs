using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;


    private void Start()
    {
        if (PlayerStats.GameStart == null) PlayerStats.GameStart = DateTime.Now;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End level now");
            StartCoroutine(HandleWinCondition());
        }

    }

    IEnumerator HandleWinCondition()
    {
        PlayerStats.Level++;
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0; //handle time -> stop it
        loseLabel.SetActive(true);
    }

    public void LevelTimerFinished()
    {
        Debug.Log("Time is up");

        levelTimerFinished = true;
        StopSpawners();
    }


    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
