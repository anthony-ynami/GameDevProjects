using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class whatsayyyyy : MonoBehaviour {

    public string currentRoom;
    public string myText;

    private string room_north;
    private string room_south;
    private string room_east;
    private string room_west;

    private bool hasKey = false;





    // Use this for initialization
    void Start () {
        //change text to read "we ran our scene"
        myText = "We ran our scene";

        currentRoom = "entry";


}

// Update is called once per frame
void Update () {
  
    //if the player presses space bar, set the text object text field to say
    //"you pressed spwacebwar"
    /*if (Input.GetKeyDown(KeyCode.Space))
    {
        GetComponent<Text>().text = "you pressed spwacebwar"
    }
    */

        room_east = "nil";
        room_north = "nil";
        room_south = "nil";
        room_west = "nil";
        

        //if i'm in the entryway, i want the game to say "you are in the entryway"
        if (currentRoom == "entry")
        {
            room_north = "hallway";

            myText = "you are in the entryway.\n";
            myText += "the entry way is cool.";

        }
        else if (currentRoom == "hallway")
        {
            room_east = "kitchen";
            room_south = "entry";
            room_west = "locked door";

            myText = "you are in the hallway";
        }
        else if (currentRoom == "kitchen")
        {
            room_west = "hallway";

            if (!hasKey)
            {
                myText = "you are in the kitchen. you see something sparkling in the  drain. Press\"i\" to inspect";
            }
            else
            {
                myText = "you are in the kitchen";
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                currentRoom = "drain";
            }
        }
        else if (currentRoom == "drain")
        {
            myText = "heyo you gots the keyyy. press down to go back";
            hasKey = true;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentRoom = "kitchen";
            }
        }
        else if (currentRoom == "locked door")
        {
            if (hasKey)
            {
                myText = "CONGRATS YOU MADE ITTT LET'S CAKE";
            }
            else
            {
                myText = "sorry room is locked yafool";
            }
        }
        else
        {
            myText = "you have fallen into a void because the game designer is a crap game designer and the developer is bad too and a variable is set wrong";
            myText += "\n press down to return to the beginning ";

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentRoom = "entry";
            }
        }
        




        myText +="\n\n";
        if (room_south != "nil")
        {
            myText += "Press Up to go to the " + room_south + "\n";

        }
   
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentRoom = room_north;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentRoom = room_south;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentRoom = room_east;
         } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentRoom = room_west;
         };


        GetComponent<Text>().text = myText;

	}
}
