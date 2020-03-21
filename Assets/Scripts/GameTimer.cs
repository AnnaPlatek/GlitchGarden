using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")][SerializeField] float levelTime = 30;

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timeFinished = (Time.timeSinceLevelLoad >=levelTime);
        if (timeFinished)
        {
            Debug.Log("Level timer expired");
        }
    }
}
