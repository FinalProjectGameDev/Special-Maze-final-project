using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordExposure : MonoBehaviour
{
    [SerializeField]
    public GameObject[] images;

    [SerializeField]
    public GameObject gameObjectGenerateRandomNumber;

    private GenerateRandomNumber generateRandomNumber;
    public int theChoosenNum;
    public bool onButton;

    public Animator player;

    string _currentSelectedCharName;


    void OnTriggerEnter(Collider other)
    {
        onButton = true;
    }

    void OnTriggerExit(Collider other)
    {
        onButton = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        generateRandomNumber = gameObjectGenerateRandomNumber.GetComponent<GenerateRandomNumber>();
        theChoosenNum = generateRandomNumber.theChoosenNum;

        _currentSelectedCharName = PlayerPrefs.GetString("CurrentSelectedCharacter", "Deaf");

        if (_currentSelectedCharName == "Blindness" || _currentSelectedCharName == "Deaf")
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onButton)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (player) player.SetTrigger("push");
                Debug.Log("E Preessed");
                if (!images[theChoosenNum].gameObject.activeSelf)
                {
                    images[theChoosenNum].gameObject.SetActive(true);
                    //Cursor.visible = true;
                    //Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    images[theChoosenNum].gameObject.SetActive(false);
                }
            }
        }
    }

    void OnGUI()
    {
        GUIStyle gustyle = new GUIStyle(GUI.skin.box);
        gustyle.fontSize = 40;
        if (onButton)
        {
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 60, 600, 50), "Press E for accessibility", gustyle);
        }

    }
}
