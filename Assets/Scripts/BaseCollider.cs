using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("I hit " + otherCollider.name);
        FindObjectOfType<LivesDisplay>().TakeLife();
    }
}
