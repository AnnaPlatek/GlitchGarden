using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfAttackersDisplay : MonoBehaviour
{
    Text numberOfAttackersText;

    void Start()
    {
        numberOfAttackersText = GetComponent<Text>();
        UpdateNumberOfAttackersDisplay();
    }

    public void UpdateNumberOfAttackersDisplay()
    {
        numberOfAttackersText.text = FindObjectOfType<LevelController>().ShowNumberOfAttackers().ToString();
    }
}
