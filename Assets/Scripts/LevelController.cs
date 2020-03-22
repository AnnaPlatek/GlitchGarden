using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimeFinished = false;

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
            Debug.Log("End Level Now");
            FindObjectOfType<LoadLevel>().LoadNextLevel();
        }
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
