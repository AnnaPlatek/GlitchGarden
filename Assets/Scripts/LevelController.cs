using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelController : MonoBehaviour
{
    [SerializeField] public GameObject winLabel;
    [SerializeField] public GameObject lostLabel;
    int numberOfAttackers = 0;
    bool levelTimeFinished = false;
    int timeToWait = 4;
    bool levelEnd = false;

    public void Start()
    {
        winLabel.SetActive(false);
        lostLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
        FindObjectOfType<NumberOfAttackersDisplay>().UpdateNumberOfAttackersDisplay();
    }

    public void AttackerKilled()
    {
        //Debug.Log("Attacker Killed");
        numberOfAttackers--;
        FindObjectOfType<NumberOfAttackersDisplay>().UpdateNumberOfAttackersDisplay();
        EndLevel();
    }

    private void EndLevel()
    {
        if (numberOfAttackers <= 0 && levelTimeFinished)
        {
            //Debug.Log("End Level Now");
            levelEnd = true;
            StartCoroutine(WaitForTime());

            if (winLabel != null)
            {
                winLabel.SetActive(true);
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public void ShowLevelLost()
    {
        if (lostLabel != null)
        {
            lostLabel.SetActive(true);
            Time.timeScale = 0;
        }
 
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
        EndLevel();
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

    public int ShowNumberOfAttackers()
    {
        return numberOfAttackers;
    }

    private void Update()
    {
        Debug.Log(levelTimeFinished);
        Debug.Log(levelEnd);
    }
}
