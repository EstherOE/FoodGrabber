using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthManager : MonoBehaviour
{
    public Text HeathText;
  
    
    int mainHealth;
    PlayerMovement control;
    internal float _currenthealth;
    public int maxHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
        control = FindObjectOfType<PlayerMovement>();
        mainHealth = 100;
        _currenthealth = maxHealth;
        HeathText.text = "Health: " + _currenthealth;
        
    }
    private void Update()
    {
       if(Input.GetKey(KeyCode.Space))
        {

            killPlayer(10);
        }
    }
    public void killPlayer(int number)
    {
        if (_currenthealth == 0)
        {

            _currenthealth = 0;
            HeathText.text = "Health: " + _currenthealth;
        }
        else
        {

            _currenthealth -= number;

            HeathText.text = "Health: " + _currenthealth;
        }

    }

}
