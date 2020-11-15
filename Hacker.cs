//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;





public class Hacker : MonoBehaviour{


    //gamestate
    int level;
    string password;
    enum Screen {MainMenu, Password, Win};
    Screen current;
    const string menuHint = "Menu can be typed at any time";


    //passwords
    string[] level1Passwords = {"dog", "cat", "bird", "frog", "donkey"};
    string[] level2Passwords = {"red", "blue", "yellow", "green", "white"};
    string[] level3Passwords = {"yellow dog", "green cat", "blue bird", "red frog", "white donkey"};


    // Start is called before the first frame update
    void Start() {
        showMainMenu();
    }

    void showMainMenu(){
        Screen current = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome!!!!!!!!");
        Terminal.WriteLine("Press Enter Level Number (1-3)");
    }


    void OnUserInput(string input) {
        
        if (input == "Menu" || input == "menu"){
            current = Screen.MainMenu;
            showMainMenu();
        }

        else if (current == Screen.MainMenu) {
            runMainMenu(input);

        }

        else if (current == Screen.Password) {
            checkPassword(input);
        }


    }

    void runMainMenu(string input) {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");

        if (isValidLevel) {
            level = int.Parse(input);
            askForPassword();
        }
        else {
            Terminal.WriteLine("Not a choice!");
        }

    }



    void askForPassword(){
        current = Screen.Password;
        Terminal.ClearScreen();
        setRandomPassword();

        Terminal.WriteLine("Enter Password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);


    }

    void setRandomPassword() {
        switch(level){
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length - 1)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length - 1)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length - 1)];
                break;

            default:
                Debug.LogError("Invalid Level Number");
                break;
        }


    }




    void checkPassword(string input) {

        if (input == password) {
            displayWinScreen();

        }

        else {

            //Terminal.WriteLine("WRONG!!!");
            askForPassword();
        }
    }

    void displayWinScreen(){
        current = Screen.Win;
        Terminal.ClearScreen();
        showLevelReward();
    }

    void showLevelReward(){
        Terminal.WriteLine("Correct");

        Terminal.WriteLine(@"

    Winner Winner!!!!!!!

    Chicken Dinner!!!!!!


        ");
        Terminal.WriteLine(menuHint);
        
        
    }


    // Update is called once per frame
    void Update()
    {
        
         
    }
}
