using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    public Button startButton;
    public Button confirmButton;
    public TMP_Text textBox;
    public TMP_Text timerBox;
    public TMP_InputField inputField;

    GameObject[] cable1Parts = new GameObject[3];






    public GameObject calbe1Head;
    public GameObject calbe1Middle;
    public GameObject calbe1Bottom;

    public int number1;
    public int number2;
    public int number3;

    public int playerInput;
    public float timeRemaining = 200;
    public bool gameStarted = false;

    // checks if more than one Manager are in the scene and creates a way to call the instance of this class
    private void Awake()
    {

        inputField.gameObject.SetActive(false);
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Manager in the scene");
        }
        instance = this;

    }

    private void Start()
    {
        cable1Parts[0] = calbe1Head;
        cable1Parts[1] = calbe1Middle;
        cable1Parts[2] = calbe1Bottom;

    }




    // retuns the instance of this class when called
    public static Manager GetInstance()
    {
        return instance;
    }


    /* 
     The function designated for the "Start" Button 
     Activates the InputField and Confirm Button
     Deactivates the Start Buttton
     Changes the Text in the textbox
     Assigns a random number to an integer-Variable 
    */
    public void StartButtonPress()
    {

        gameStarted = true;

        inputField.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(true);  

        textBox.text = "Guess the Number\n\nIt's between 1 and 5!";

        for(int i = 0; i < 3; i++)
        {
            CableColorer(cable1Parts[i]);
        }



    }


    void CableColorer(GameObject cable)
    {
        int number = Random.Range(1, 30);


        if (number > 0 & number <= 10)
        {
            cable.GetComponent<SpriteRenderer>().color = Color.cyan;


        }
        else if (number > 10 & number <= 20)
        {

            cable.GetComponent<SpriteRenderer>().color = Color.green;


        }
        else if (number > 20 & number <= 30)
        {

            cable.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }


    // Function for the Confirm Button
    public void ConfirmButtonPress()
    {
        // EndEdit();
    }


    // Allows to create the same Results as the "Confirm" Button through a Buttonpress
    public void Update()
    {
        if (timeRemaining > 0)
        {
            if (gameStarted)
            {
                timeRemaining -= Time.deltaTime;
                timerBox.text = timeRemaining.ToString();
                
            }

        }
        else
        {
            EndResults(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //EndEdit();
        }


    }

    /* Parses the numbers out off the InputField
     * Checks if the Playernumber equals the Integer Variable and acts accordingly
     * Clears the InputField
     *
    public void EndEdit()
    {
        int.TryParse(inputField.text, out playerInput) ;

        if (playerInput == number)
        {
            EndResults(true);
        }
        else if (timeRemaining <= 0)
        {
            EndResults(false);
        }
        else if (playerInput > number)
        {
            timeRemaining -= 5;
            textBox.text = "Oh nawr, that's wrong!\n\n The number is smoller\n\n Try again!";
        }
        else if (playerInput < number)
        {
            timeRemaining -= 5;
            textBox.text = "Oh nawr, that's wrong!\n\n The number is bigga\n\n Try again!";
        }

        inputField.text = "";


    }
    */

    // Gives the Endresult of the Game
    // Resets the Buttons and InputField
    void EndResults(bool con)
    {
        if (con == true)
        {
            textBox.text = "Gewonnen!\n\n Play again!";
        }
        else
        {
            textBox.text = "Verloren!\n\n Try again!";
        }

        timeRemaining = 200;
        inputField.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        confirmButton.gameObject.SetActive(false);

        gameStarted = false;
    }




}
