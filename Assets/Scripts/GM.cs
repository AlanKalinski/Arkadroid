using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public static GM instance = null;

    public float resetDelay = 1f;
    public GameObject bricksPrefab;
    public GameObject deathParticles;

    public GameObject paddleOne;
    public GameObject paddleTwo;

    public Text scoreText;
    private int player1points, player2points;

    private GameObject clonePaddleOne;
    private GameObject clonePaddleTwo;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
    }

    public void pointForPlayer1()
    {
        player1points++;
        updateScoreText();
        LoseLife();
    }

    public void pointForPlayer2()
    {
        player2points++;
        updateScoreText();
        LoseLife();
    }

    private void updateScoreText()
    {
        scoreText.text = string.Format("Player One {0} : {1} Player Two", player1points, player2points);
    }

    public void Setup()
    {
        clonePaddleOne = Instantiate(paddleOne, transform.position, Quaternion.identity) as GameObject;
        clonePaddleTwo = Instantiate(paddleTwo, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        Instantiate(deathParticles, clonePaddleOne.transform.position, Quaternion.identity);
        Destroy(clonePaddleOne);

        Instantiate(deathParticles, clonePaddleTwo.transform.position, Quaternion.identity);
        Destroy(clonePaddleTwo);
       
        Invoke("SetupPaddle", resetDelay);
    }

    void SetupPaddle()
    {
        if (clonePaddleOne != null) clonePaddleOne = Instantiate(clonePaddleOne, new Vector3(0, -14.5f, 0), Quaternion.identity) as GameObject;
        if (clonePaddleTwo != null) clonePaddleTwo = Instantiate(clonePaddleTwo, new Vector3(0, 14.5f, 0), Quaternion.identity) as GameObject;
    }

}
