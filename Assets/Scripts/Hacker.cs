
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuPrompt = "Type 'menu' to start over.";
    string[] level1Passwords = { "personnel", "personal", "person", "fleshhog" };
    string[] level2Passwords = { "password", "fastword", "gasport", "snorgborger" };
    string[] level3Passwords = { "alita", "neo", "trinity", "sozzled" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private void Update()
    {
        // Testing the Random Range
        //int index = Random.Range(0, level1Passwords.Length);
        //print(index);
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack?\n");
        Terminal.WriteLine("Press 1 for the personnel database");
        Terminal.WriteLine("Press 2 for the confidential files");
        Terminal.WriteLine("Press 3 for the MATRIX\n");
        Terminal.WriteLine("Enter your selection: \n");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "42") // Easter egg
        {
            Terminal.WriteLine("Ah! You found the Meaning of Life.\n");
            Terminal.WriteLine("Enter your selection: \n");
            Terminal.WriteLine("\n" + menuPrompt);
        }
        else if (input == "11") // Easter egg
        {
            Terminal.WriteLine("This one goes all the way up to 11.\n");
            Terminal.WriteLine("Enter your selection: \n");
            Terminal.WriteLine("\n" + menuPrompt);
        }
        else
        {
            Terminal.WriteLine("Mmmm . . . does not compute.\nTerminate user.\n");
            Terminal.WriteLine("Enter your selection: \n");
            Terminal.WriteLine("\n" + menuPrompt);
        }
    }

    void AskForPassword()
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        print(level3Passwords.Length);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter the password. \n\nHere's hint:  \n\n" + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("No worky.  Try harder.\n");
                break;
        }
    }

    void CheckPassword(string input)
    {

        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("\nInvalid data!\n \nPlease try again.\n");
            Terminal.WriteLine("\n" + menuPrompt);
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("\n" + menuPrompt);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("\nBrilliant job!\n\nHave a peek at this dossier!\n");
                Terminal.WriteLine(@"
                            _____
                   ________/    /
                  /             //
                 /             //
                /_____________//
                "
                );
                break;
            case 2:
                Terminal.WriteLine("\nGood show!\n\nPig out on this data!\n");
                Terminal.WriteLine(@"
                  \      /
                  [0] [0]
                ___________
               |   _   _   |
               |  /_/ /_/  |
               |___________|
                "
                );
                break;
            case 3:
                Terminal.WriteLine("\nSick!\n\nYou've enter the MATRIX!\n");
                Terminal.WriteLine(@"
            k   [   7    5    3   
            %   r   #    ^    0
            $   @   h    Y    I
            +   :   ;    |    ?

                "
                );
                break;
            default:
                Debug.LogError("Invalid level reached.");
                break;
        }

    }
}
