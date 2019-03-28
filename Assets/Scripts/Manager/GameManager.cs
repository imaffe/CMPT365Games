using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int m_NumRoundsToWin = 3;
    // public CameraControl m_CameraControl; 
    public Text m_MessageText;
    public GameObject m_Chick;
    public GameObject m_Ruby;
    public PlayerManager [] m_Players;


    private int m_CurrentRounderNumber;
    private PlayerManager m_RoundWinner;
    private PlayerManager m_GameWinner;

	// Use this for initialization
	private void Start () {


        SpawnChicks();
        SetCameraTargets();

        StartCoroutine(GameLoop());
	}
	
	// Update is called once per frame
	private void Update () {
		
	}


    private void SpawnChicks()
    {
        // create the players on the map
    }

    private void SetCameraTargets()
    {
        // use to assign camera control the game objects' transform matrix, not needed if we don't move camera
    }

    private IEnumerator GameLoop ()
    {
        yield return StartCoroutine(RoundStarting());

        yield return StartCoroutine(RoundPlaying());

        yield return StartCoroutine(RoundEnding());

        if (m_GameWinner != null)
        {
            //TODO : this is used 
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }

    private IEnumerator RoundStarting ()
    {
        ResetAllPlayers();
        DisablePlayerControl();

        // if we use camera, delete the following comment
        // m_CameraControl.SetStartPositionAndSize();

        m_CurrentRounderNumber++;
        m_MessageText.text = "ROUND" + m_CurrentRounderNumber;

        yield return new WaitForSeconds(1); // the actual number here can be adjusted
    }

    private IEnumerator RoundPlaying()
    {
        EnablePlayerControl();

        // if we use camera, delete the following comment
        // m_CameraControl.SetStartPositionAndSize();

        
        m_MessageText.text = string.Empty;

        yield return new WaitForSeconds(1); // the actual number here can be adjusted
    }

    private IEnumerator RoundEnding()
    {
        DisablePlayerControl();

        m_RoundWinner = null;
        m_RoundWinner = GetRoundWinner();

        if (m_RoundWinner != null)
            m_RoundWinner.m_Wins++;

        m_GameWinner = GetGameWinner();

        string message = GetEndMessage();
        m_MessageText.text = message;

        m_MessageText.text = string.Empty;

        yield return new WaitForSeconds(1); // the actual number here can be adjusted
    }


    // for disable/enable player control
    private void EnablePlayerControl()
    {

    }

    private void DisablePlayerControl()
    {

    }

    // reset all the players : chick and ruby
    private void ResetAllPlayers()
    {

    }


    // some util function
    private PlayerManager GetGameWinner()
    {
        // find out if there is a winner, if not return null
    }

    private PlayerManager GetRoundWinner()
    {
        // find out if there is a winner, if not return null
    }

    private string GetEndMessage()
    {
        // return what need to be played when a round ends
        return null;
    }
}
