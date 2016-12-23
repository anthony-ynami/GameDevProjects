using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyTextAdventure : MonoBehaviour {



	public AudioSource sfxSource;
	public Camera mainCam;

	//declaring an audioClip so I can change the SFX later.
	public AudioClip winSound;
    public AudioClip keyget;


	public Image key1;
    public Image key2;

	private string currentRoom;
	private string myText;

	private bool hasKey1 = false;
    private bool hasKey2 = false;

    //variables to store possible room connections.
    private string room_up;
    private string room_down;
    private string room_left;
    private string room_right;

    // Called the moment that the object is created
    // We use this for intitilization;
    void Start () {
		//change text to read "We ran our scene."
		myText = "We ran our scene.";
		currentRoom = "title";
	}

    // Update is called once per frame
    void Update() {        

        //we set our rooms to nil, so that if we haven't overwritten them by the time
        //we check for keypresses, we know there's no room.
        room_up = "nil";
        room_down = "nil";
        room_left = "nil";
        room_right = "nil";

        //resetting the background and text color, so that if i leave a room
        //where I change it, it doesn't stay that color
        mainCam.backgroundColor = Color.blue;
        GetComponent<Text>().color = Color.white;

        // key images

        if (hasKey1 == true) { key1.enabled = true; }
        else { key1.enabled = false; }

        if (hasKey2 == true ) { key2.enabled = true; }
        else { key2.enabled = false; }

        // else, check the other statements.
        if (currentRoom == "title") {
            myText = "Aquarium\n\nBy Anthony Ynami\n\nPress Space to Begin";

            if (Input.GetKeyDown(KeyCode.Space)) {
                currentRoom = "lobby";
            }
        } else if (currentRoom == "lobby") {

            room_up = "main hall";
            room_down = "exit";

            myText = "You are standing in the lobby.\n";
            myText += "The doors are locked \n apparently you got lost before they closed";


        } else if (currentRoom == "main hall") {

            room_up = "outdoor exhibits";
            room_down = "lobby";
            room_left = "bathroom";
            room_right = "indoor exhibits";

            myText = "You are in the main hall.";

        } else if (currentRoom == "bathroom") {

            room_right = "main hall";

            myText = "You are in the bathroom.\n need to pee?";

            if (Input.GetKeyDown(KeyCode.P))
            {
                currentRoom = "shhh";
            }

        } else if (currentRoom == "shhh") {
            //changing background color and text color
            mainCam.backgroundColor = Color.black;
            GetComponent<Text>().color = Color.red;

            myText = "After you flush a wall moves to reveal a sort of chamber that might have secrets\n";
            myText += "Press \"i\" to inspect .";
            if (Input.GetKeyDown(KeyCode.I)) {
                currentRoom = "oh";

            }
        } else if(currentRoom == "oh"){
            mainCam.backgroundColor = Color.black;
            GetComponent<Text>().color = Color.red;

            myText = "You found half a key!\n Dank chamber";

            if (!hasKey2) {
                sfxSource.clip = keyget;
                sfxSource.Play();

            }hasKey2 = true;

            myText += "\n\nPress Space to return to the bathroom.";

            if (Input.GetKeyDown(KeyCode.Space)) {
                currentRoom = "bathroom";
            }

        } else if (currentRoom == "outdoor exhibits") {

            room_down = "main hall";
            room_left = "dolphin pool";
            room_right = "penguin island";

            myText = "You are standing in the outdoor exhibits";

        } else if (currentRoom == "dolphin pool") {

            room_right = "outdoor exhibits";

            myText = "You are near the dolphin pool\n";
            myText += "A dolphin is signaling to you.\n Press \"i\" to inspect";

            if (Input.GetKeyDown(KeyCode.I)) {
                currentRoom = "hi dolphin";
            }

        } else if (currentRoom == "hi dolphin") {

            myText = "The dolphin tells you: \"HI if you wanna pee, press 'P'\"\n";
            myText += "\nPress Space to go back to the dolphin pool";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentRoom = "dolphin pool";
            }

        } else if (currentRoom == "penguin island") {

            room_left = "outdoor exhibits";

            myText = "You're standing by the penguin island\n";
            myText += "You watch a penguin helplessly lose a fight after getting cheated on";

        } else if (currentRoom == "indoor exhibits") {

            room_left = "main hall";
            room_up = "open sea gallery";
            room_down = "touch tank";

            myText = "You are standing in the indoor exhibits";

        } else if (currentRoom == "open sea gallery") {

            room_down = "indoor exhibits";

            myText = "You are standing in the open sea gallery\n";
            myText += "It truly is amazing how many different creatures can live in the ocean";

        } else if (currentRoom == "touch tank") {

            room_up = "indoor exhibits";

            myText = "You are by the touch tank.\n You're tempted to touch a starfish.\n";
            myText += "Press \"t\" to touch!";

            if (Input.GetKeyDown(KeyCode.T)) {
                currentRoom = "touching";
            }
        } else if (currentRoom == "touching") {
            mainCam.backgroundColor = Color.black;
            GetComponent<Text>().color = Color.red;

            myText = "Feels kinda slimy\n You found half a key!\n";
            if (!hasKey1) {
                sfxSource.clip = keyget;
                sfxSource.Play();
            }
            hasKey1 = true;

            myText += "\n Press Space to return to the touch tank";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentRoom = "touch tank";
            }
        }  else if (currentRoom == "exit") {

			if (hasKey1 & hasKey2) {
				myText = "YOU'RE FREEEE!\n now to find out how to get home . . .";

                sfxSource.clip = winSound;
                if (!sfxSource.isPlaying)
                {
                    sfxSource.Play();
                }
            }
            else {

                room_up = "lobby";

				myText = "Doors are still locked, you need a full key.\n";

			}


		} else {

			myText = "You have fallen into a void because the game designer is a garbage game designer and the developer is bad too and some variable is set wrong, specifically currentRoom.";

		}


		// here we're checking for keyboard input
		// if a directional key is pressed
		// we go to the corresponding room.

		myText += "\n\n";
		if (room_up != "nil"){

			myText += "Press Up to go to the " + room_up + "\n";

			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				
				currentRoom = room_up;

			}
		}


		if (room_down != "nil"){

			myText += "Press Down to go to the " + room_down + "\n";

			if (Input.GetKeyDown(KeyCode.DownArrow)){
				
				
				currentRoom = room_down;

			}
		}
	
		if (room_right != "nil"){

			myText += "Press Right to go to the " + room_right + "\n";

			if (Input.GetKeyDown(KeyCode.RightArrow)){
				
				currentRoom = room_right;

			}
		}

		if (room_left != "nil") {

			myText += "Press Left to go to the " + room_left + "\n";

			if (Input.GetKeyDown(KeyCode.LeftArrow)){
				
				currentRoom = room_left;

			}
		}

		//We are acccesing the text component, then using dot notation
		//to modify the text attribute.
		GetComponent<Text>().text = myText;

	}

}
