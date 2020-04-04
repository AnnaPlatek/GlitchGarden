using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    int timeToWait = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        Destroy(gameObject);
    }
}
