using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour {

    public int PlayerTurn = 1;
    public int Round = 1;
    public Transform PlayerInitialPosition;
    public Transform PinInitialPosition;
    public bool whichPlayer;

    private bool m_isRunning = false;
    public float m_timeElapsed = 0.0f;
    public float endTime = 1.0f;

    public Vector3 playerPosition;
    public Vector3 pinPosition;

    private GameObject Pin1;
    private PinGravity Pin1Script;
    private GameObject Forces1;
    private Pin1 Forces1Script;
    private ForceBar forcebar;
    private GameObject display;
    public Display displayScript;
    private float p1distanceFloat1;
    private float p1distanceFloat2;
    private float p1distanceFloat3;
    private float p2distanceFloat1;
    private float p2distanceFloat2;
    private float p2distanceFloat3;
    private GameObject controlPlayer;
    private float maxTotal;


    public int getPlayerTurn()
    {
        return PlayerTurn;
    }
    public int getRound()
    {
        return Round;
    }

    public float getp1distance1()
    {
        return p1distanceFloat1;
    }
    public float getp1distance2()
    {
        return p1distanceFloat2;
    }
    public float getp1distance3()
    {
        return p1distanceFloat3;
    }

    public float getp2distance1()
    {
        return p2distanceFloat1;
    }
    public float getp2distance2()
    {
        return p2distanceFloat2;
    }
    public float getp2distance3()
    {
        return p2distanceFloat3;
    }

    public float getp1maxdistance()
    {
        

        float p1max = 0;
        if (p1distanceFloat1 > p1distanceFloat2)
        {
            if (p1distanceFloat1 > p1distanceFloat3)
                p1max = p1distanceFloat1;
        }
        if (p1distanceFloat2 > p1distanceFloat1)
        {
            if (p1distanceFloat2 > p1distanceFloat3)
                p1max = p1distanceFloat2;
        }
        if (p1distanceFloat3 > p1distanceFloat1)
        {
            if (p1distanceFloat3 > p1distanceFloat2)
                p1max = p1distanceFloat3;
        }

        return p1max;
    }

    public float getp2maxdistance()
    {


        float p2max = 0;
        if (p2distanceFloat1 > p2distanceFloat2)
        {
            if (p2distanceFloat1 > p2distanceFloat3)
                p2max = p2distanceFloat1;
        }
        if (p2distanceFloat2 > p2distanceFloat1)
        {
            if (p2distanceFloat2 > p2distanceFloat3)
                p2max = p2distanceFloat2;
        }
        if (p2distanceFloat3 > p2distanceFloat1)
        {
            if (p2distanceFloat3 > p2distanceFloat2)
                p2max = p2distanceFloat3;
        }

        return p2max;
    }

    public string declareWinner(float player1, float player2)
    {
        string player1String = "Player 1 wins!";
        string player2String = "Player 2 wins!";
        if (player1 > player2)
        {
            maxTotal = player1;
            return player1String;
        }
        if (player2 > player1)
        {
            maxTotal = player2;
            return player2String;
        }
        else return "Nobody Wins!  Ha Ha!";
    }

    // Use this for initialization
    void Start()
    {
        p1distanceFloat1 = 0.0f;
        p1distanceFloat2 = 0.0f;
        p1distanceFloat3 = 0.0f;
        p2distanceFloat1 = 0.0f;
        p2distanceFloat2 = 0.0f;
        p2distanceFloat3 = 0.0f;
        PlayerTurn = 1;
        Round = 1;
        whichPlayer = false;
        endTime = 10.0f;
        forcebar = GameObject.FindWithTag("ForceBar").GetComponent<ForceBar>();

        Forces1 = GameObject.FindWithTag("Player1");
        Forces1Script = Forces1.GetComponent<Pin1>();

        display = GameObject.FindWithTag("Display");
        displayScript = display.GetComponent<Display>();

        Pin1 = GameObject.FindWithTag("Pin1");
        Pin1Script = Pin1.GetComponent<PinGravity>();
        playerPosition = GameObject.FindWithTag("PlayerSpawn").transform.position;
        pinPosition = GameObject.FindWithTag("PinSpawn").transform.position;
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isRunning = !m_isRunning;
        }
    }

    private void FixedUpdate()
    {
        if (m_isRunning)
        {
            m_timeElapsed += Time.fixedDeltaTime;

            displayScript.setTimer(m_timeElapsed);
        }
        else
        {
            displayScript.setTimer(0.0f);
        }


        if (m_isRunning)
        {
            //player 1
            if (PlayerTurn == 1)
            {

                if (Round == 1)
                {
                    if (m_timeElapsed >= endTime)
                    {
                        
                        p1distanceFloat1 = Pin1Script.getDistance();
                        Forces1Script.setPosition(playerPosition);
                        Pin1Script.setPosition(pinPosition);
                        Pin1Script.restart();
                        displayScript.restart();
                        //forcebar.restart();
                        m_isRunning = !m_isRunning;
                        m_timeElapsed = 0.0f;
                        displayScript.restart();
                        Round = 2;
                    }
                }
                else if (Round == 2)
                {
                    if (m_timeElapsed >= endTime)
                    {
                        
                        p1distanceFloat2 = Pin1Script.getDistance();
                        m_isRunning = !m_isRunning;
                        Forces1Script.setPosition(playerPosition);
                        Pin1Script.setPosition(pinPosition);
                        Pin1Script.restart();
                        m_timeElapsed = 0.0f;
                        //forcebar.restart();
                        displayScript.restart();
                        Round = 3;
                    }
                }
                else if (Round == 3)
                {
                    if (m_timeElapsed >= endTime)
                    {
                        
                        p1distanceFloat3 = Pin1Script.getDistance();
                        string temp = getp1maxdistance().ToString();
                        displayScript.setPlayer1Max(temp);
                        m_isRunning = !m_isRunning;
                        Forces1Script.setPosition(playerPosition);
                        Pin1Script.setPosition(pinPosition);
                        Pin1Script.restart();
                        m_timeElapsed = 0.0f;
                        //forcebar.restart();
                        displayScript.restart();
                        Round = 1;
                        PlayerTurn = 2;
                        displayScript.setPlayer();
                    }
                }
            }
            //player 2
            if (PlayerTurn == 2)
            {

                if (Round == 1)
                {
                    if (m_timeElapsed >= endTime)
                    {

                        p2distanceFloat1 = Pin1Script.getDistance();
                        Forces1Script.setPosition(playerPosition);
                        Pin1Script.setPosition(pinPosition);
                        Pin1Script.restart();
                        displayScript.restart();
                        //forcebar.restart();
                        m_isRunning = !m_isRunning;
                        m_timeElapsed = 0.0f;
                        displayScript.restart();
                        Round = 2;
                    }
                }
                else if (Round == 2)
                {
                    if (m_timeElapsed >= endTime)
                    {

                        p2distanceFloat2 = Pin1Script.getDistance();
                        m_isRunning = !m_isRunning;
                        Forces1Script.setPosition(playerPosition);
                        Pin1Script.setPosition(pinPosition);
                        Pin1Script.restart();
                        m_timeElapsed = 0.0f;
                        //forcebar.restart();
                        displayScript.restart();
                        Round = 3;
                    }
                }
                else if (Round == 3)
                {
                    if (m_timeElapsed >= endTime)
                    {

                        p2distanceFloat3 = Pin1Script.getDistance();
                        string temp = getp2maxdistance().ToString();
                        displayScript.setPlayer2Max(temp);
                        m_isRunning = !m_isRunning;
                        Forces1Script.setPosition(playerPosition);
                        Pin1Script.setPosition(pinPosition);
                        Pin1Script.restart();
                        m_timeElapsed = 0.0f;
                        //forcebar.restart();
                        displayScript.restart();

                        displayScript.DisplayWinner(declareWinner(getp1maxdistance(), getp2maxdistance()));
                        /*
                        Round = 1;
                        PlayerTurn = 2;
                        displayScript.setPlayer();
                        */
                    }
                }
            }
        }
    }
}
