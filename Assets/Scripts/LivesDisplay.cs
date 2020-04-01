using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baselives = 5f;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;

    void Start()
    {
        lives = baselives - (PlayerPrefsController.GetDifficulty());
        livesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("diffuculty setting currently is" + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <=0)
        {
            FindObjectOfType<LevelController>().ShowLevelLost();
            //FindObjectOfType<LoadLevel>().LoadLoseScreen();
        }
    }


}
