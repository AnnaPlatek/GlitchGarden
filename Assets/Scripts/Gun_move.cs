using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_move : MonoBehaviour
{
    float gunSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * gunSpeed * Time.deltaTime);

    }
}
