using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasHearingAid : MonoBehaviour
{
    public bool onAid;
    public Camera cam;
    public GameObject player;
    public Player playerP;

    public GameObject AidOnPlayer;

    string _currentSelectedCharName;

    void OnTriggerEnter(Collider other)
    {
        if (_currentSelectedCharName == "Deaf") onAid = true;
    }

    void OnTriggerExit(Collider other)
    {
        onAid = false;
    }

    void Start()
    {
        _currentSelectedCharName = PlayerPrefs.GetString("CurrentSelectedCharacter", "Deaf");

        if (_currentSelectedCharName == "Deaf")
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onAid && Input.GetKeyDown(KeyCode.E))
        {
            if (player) player.GetComponent<Animator>().SetTrigger("lift");
            player.GetComponent<AudioListener>().enabled = true;
            this.gameObject.SetActive(false);
            AidOnPlayer.SetActive(true);
            playerP.hasHearingAid = true;
        }
    }

    void OnGUI()
    {
        GUIStyle gustyle = new GUIStyle(GUI.skin.box);
        gustyle.fontSize = 40;
        if (onAid)
        {
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 60, 600, 50), "Press E to Get the Hearing Aid", gustyle);
        }
    }
}
