using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlaySpeed : MonoBehaviour
{

    public void PauseButton()
    {
    
        Time.timeScale = 0;
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
    }

    public void SpeedButton()
    {
        Time.timeScale = 2;
    }

    //private void OnMouseDown()
    //{
    //    var buttons = FindObjectsOfType<PausePlaySpeed>();
    //    foreach (PausePlaySpeed button in buttons)
    //    {
    //        button.GetComponent<SpriteRenderer>().color = new Color32(70, 70, 70, 255);
    //    }
    //
    //    GetComponent<SpriteRenderer>().color = Color.white;
    //    //FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    //}

}
