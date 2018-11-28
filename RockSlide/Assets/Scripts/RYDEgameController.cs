using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RYDEgameController : MonoBehaviour {
    public Text youWin;
    public Text youDie;
    public GameObject player;
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;


    private bool timer;
    private bool gameOver;
    private int score;
    private float startTime = 0.0f;


    void Start()
    {

        youDie.text = "";
        youWin.text = "";

        StartCoroutine(SpawnWaves());

        score = 0;


        timer = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (player == null)
        {
            youDie.gameObject.SetActive(true);
            Debug.Log("is this happening");
        }

    }

    void Update()
    {
       
       
        if (Input.GetKey("escape"))
            Application.Quit();

        if (player == null)
        {

            startTime = 0.0f;
        }

        if (timer)
        {
            startTime += Time.deltaTime;
            if (startTime >= 1)
            {
                score += (int)startTime;
                startTime -= (int)startTime;
                //GameLoader.AddScore(1);
            }
        }
        Debug.Log("Score: " + score);

        if (score == 10)
        {
            timer = (false);
            youWin.text = "YOU WIN";
            Destroy(GameObject.FindWithTag("Rock"));
            StartCoroutine(ByeAfterDelay(2));

        }

    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);


        //GameLoader.gameOn = false;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }



        }


    }




    public void GameOver()
    {
        youDie.text = "YOU DIED";
        gameOver = true;
        StartCoroutine(ByeAfterDelay(2));
        Destroy(GameObject.FindWithTag("Rock"));
    }
}
