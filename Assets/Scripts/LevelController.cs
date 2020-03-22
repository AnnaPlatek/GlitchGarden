using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject lostLabel;
    int numberOfAttackers = 0;
    bool levelTimeFinished = false;
    int timeToWait = 4;

    public void Start()
    {
        winLabel.SetActive(false);
        lostLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        //Debug.Log("Attacker Killed");
        numberOfAttackers--;
        if (numberOfAttackers<=0 && levelTimeFinished)
        {
            //Debug.Log("End Level Now");
            StartCoroutine(WaitForTime());
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            
        }
    }

    public void ShowLevelLost()
    {
        lostLabel.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        //LoadNextLevel();
        FindObjectOfType<LoadLevel>().LoadNextLevel();
    }

    public void LevelTimerFinished()
    {
        levelTimeFinished = true;
        StopSpawners();
        Debug.Log("StopSpawners");
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
