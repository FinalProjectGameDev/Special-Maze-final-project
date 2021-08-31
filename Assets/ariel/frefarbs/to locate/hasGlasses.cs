using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class hasGlasses : MonoBehaviour
{
    public bool onGlasses;
    public Player player;

    public Animator playerAnim;
    public Camera camera;

    public Camera minimap;
    public GameObject glassesOnPlayer;

    string _currentSelectedCharName;

    void OnTriggerEnter(Collider other)
    {
        if (_currentSelectedCharName == "Blindness") onGlasses = true;
    }

    void OnTriggerExit(Collider other)
    {
        onGlasses = false;
    }

    void Start()
    {
        player.hasGlasses = false;
        _currentSelectedCharName = PlayerPrefs.GetString("CurrentSelectedCharacter", "Deaf");

        if (_currentSelectedCharName == "Blindness")
        {
            playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (onGlasses && Input.GetKeyDown(KeyCode.E))
        {
            if (playerAnim) playerAnim.SetTrigger("lift");
            camera.gameObject.SetActive(true);
            PostProcessLayer layer = camera.GetComponent<PostProcessLayer>();
            layer.enabled = false;
            PostProcessLayer mmlayer = minimap.GetComponent<PostProcessLayer>();
            mmlayer.enabled = false;
            this.gameObject.SetActive(false);
            glassesOnPlayer.SetActive(true);
            player.hasGlasses = true;
        }
    }

    void OnGUI()
    {
        GUIStyle gustyle = new GUIStyle(GUI.skin.box);
        gustyle.fontSize = 40;
        if (onGlasses)
        {
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 60, 600, 50), "Press E to Get the glasses", gustyle);
        }
    }
}