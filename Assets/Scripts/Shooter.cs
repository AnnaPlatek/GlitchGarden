using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] public GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttacherInLane())
        {
            //Debug.Log("Attacher in lane! Shoot!");
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            //Debug.Log("No attacher in lane! Relax!");
            animator.SetBool("IsAttacking", false);
        }
    }

    public bool IsAttacherInLane()
    {
        if (myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <=Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
