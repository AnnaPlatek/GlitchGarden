using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] EnemyArray;


    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawn==true)
            {
                SpawnAttacker();
            }
            
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }


    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, EnemyArray.Length);
        Spawn(EnemyArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation, transform) as Attacker;
        //newAttacker.transform.parent = transform;
    }
}
