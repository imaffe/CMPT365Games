using System;
using UnityEngine;

[Serializable]
public class PlayerManager {

    // if we want use spawn point, cancel the comment
    // public Transform m_SpawnPoint;

    // member variable we want to expose to other scripts
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public string m_PlayerText; // played on top of each object's head
    [HideInInspector] public GameObject m_Instance; // can be either a chick or a ruby
    [HideInInspector] public int m_Wins; // how many round has this player winned

    private ChickMove m_Movement;
    private GameObject m_MaskCanvas; // used to block the checker board whem menu is on

	// Use this for initialization
	public void Setup () {
        // set the m_Instance in other scripts
        m_Movement = m_Instance.GetComponent<ChickMove>();
        m_Movement.m_PlayerNumber = m_PlayerNumber; // also needs to set in other scripts

        m_PlayerText = ""; // TODO : needs to assign a default player text
	}

    public void DisableControl()
    {
        m_Movement.enabled = false;

        // TODO : what is the MaskCanvas here means ?
    }

    public void EnableControl()
    {
        m_Movement.enabled = true;
    }

    public void Reset()
    {
        // TODO : what is needed to be done in order to reset?
    }
     
}
