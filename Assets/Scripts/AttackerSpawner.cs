using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] public bool spawn = true;
    [SerializeField] public float minSpawnDelay = 1f;
    [SerializeField] public float maxSpawnDelay = 5f;
    [SerializeField] public Attacker[] EnemyArray;


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
