using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   
    private Vector3 platformStartPoint;

    public PlayerMovement movement;
    public Button restartGame;
    public Button mainScene;

    public GameObject[] foodObject;
    public GameObject deathObject;
    public GameObject FirstPos;
    public GameObject SecondPos;
    float firstPos, secondPos;
    private Vector3 playerStartPoint;
    public bool isGameActive;
    public Text timeText;
    HealthManager manager;
    float time = 120f;
    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
       
        playerStartPoint = movement.transform.position;
        restartGame.gameObject.SetActive(false);
        mainScene.gameObject.SetActive(false);

        manager = FindObjectOfType<HealthManager>();
        isGameActive = true;
        StartCoroutine(SpawnManager());
        StartCoroutine(SpawnEnemies());
        timeText.text = "Time: " + time;
    }

    private IEnumerator SpawnEnemies()
    {
        if (movement.gameOver == false)
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);
                Instantiate(deathObject, RandomPick(), Quaternion.identity);
            }
        }
    }

   private void Update()
    {
        if (movement.gameOver == false)
        {
            if (isGameActive)
            {
                time -= Time.deltaTime;
                if(time <0)
                    time = 0;
                timeText.text = "Time: " + Mathf.Round(time);
                
                int number = manager.maxHealth;

                if (number < 0)
                {
                    gameOver();
                }
            }
        }
    }
    float spawnRate = 1f;

    IEnumerator SpawnManager()
    {
        if (movement.gameOver == false)
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);
               
                int objLength = foodObject.Length;
                int randomObj = Random.Range(0, objLength);
                Instantiate(foodObject[randomObj],RandomPick(), Quaternion.identity);
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        
    }

    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
    Vector2 pos;
    
    public Vector2 RandomPick()
    {

        float numberRange = Random.Range(FirstPos.transform.position.x, SecondPos.transform.position.x);
       return  pos = new Vector2(numberRange, FirstPos.transform.position.y);

    }
    public void gameOver()
    {
        restartGame.gameObject.SetActive(true);
        mainScene.gameObject.SetActive(true);
        timeText.text = "Time: " + 0;
        movement.transform.position = new Vector2(-2.854474f, -2.366835f);
    }
}
