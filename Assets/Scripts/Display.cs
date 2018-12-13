using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    public float m_timeElapsed;
    private bool m_isRunning = false;

    private GameObject Pin1;
    private PinGravity Pin1Script;
    private GameObject Forces1;
    private Pin1 Forces1Script;
    private GameObject gameManagerObject;
    private GameManager gameManagerScript;

    private float forceFloat;
    public Text force;
    private float distanceFloat;
    public Text distance;
    private Canvas CanvasObject;
    public Text playerTurn;
    public Text playerRound;
    public Text playerSetup;

    public Text player1Max;
    public Text player2Max;
    public Text winner;
    public Text timeLeft;

    public void setPlayer()
    {
        playerSetup.text = "Player 2 plays";
    }

    public void DisplayWinner(string win)
    {
        winner.text = win;
    }
    public void setTimer(float time)
    {
        if (time !=0.0f)
            timeLeft.text = time.ToString();
        if (time == 0.0f)
            timeLeft.text = "";
    }

    public void restart()
    {

        forceFloat = Forces1Script.getForce();
        force.text = forceFloat.ToString();
        distanceFloat = Pin1Script.getDistance();
        distance.text = (distanceFloat.ToString() + " meters");
    }

    public void setPlayer1Max(string max)
    {
        player1Max.text = max;
    }
    public void setPlayer2Max(string max)
    {
        player2Max.text = max;
    }

    // Use this for initialization
    void Start () {
        CanvasObject = GetComponent<Canvas>();
        
        Forces1 = GameObject.FindWithTag("Player1");
        Forces1Script = Forces1.GetComponent<Pin1>();
        forceFloat = Forces1Script.getForce();
        force.text = "0";
        
        Pin1 = GameObject.FindWithTag("Pin1");
        Pin1Script = Pin1.GetComponent<PinGravity>();
        distanceFloat = Pin1Script.getDistance();
        distance.text = (distanceFloat.ToString() + " meters");


        gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        //playerTurn.text = gameManagerScript.getPlayerTurn().ToString();
        //playerRound.text = gameManagerScript.getRound().ToString();

        player1Max.text = "0";
        player2Max.text = "0";
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isRunning = !m_isRunning;
        }

        distanceFloat = Pin1Script.getDistance();
        distance.text = (distanceFloat.ToString() + " meters");
        //playerTurn.text = gameManagerScript.getPlayerTurn().ToString();
        //playerRound.text = gameManagerScript.getRound().ToString();
    }

    private void FixedUpdate()
    {
        if (m_isRunning)
        {
            forceFloat = Forces1Script.getForce();
            force.text = forceFloat.ToString();
        }
    }
}
