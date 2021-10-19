using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    public Text ItemscoreText;
    public Text GameOverText;
    public float Score;
   


    public bool scoreIncreasing;
    public int pointPerSecond;
    PlayerMovement movement;

   float items;
    // Start is called before the first frame update
    void Start()
    {
        ItemscoreText.text = "Score :" + Score;
        GameOverText.gameObject.SetActive(false);
        
        movement = FindObjectOfType<PlayerMovement>();

    }

   
    public void Death()
    {

        GameOverText.gameObject.SetActive(true);
    }
    public void GetScore(int dscore)
    {
        if (movement.gameOver == false)
        {
           Score += dscore;

            ItemscoreText.text = "Score: " + Mathf.Round(Score);
        }
       
    }

}
