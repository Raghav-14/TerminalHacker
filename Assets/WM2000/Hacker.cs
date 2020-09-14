using UnityEngine;

public class Hacker : MonoBehaviour
{
    //array for passwords

    string[] Level1Passwords = {"book","page","pagenumber","index","chapter" };
    string[] Level2Passwords = { "arrest","cops","prison","visitors","commander"};
    //varibales
    int level;
    enum Screen { MainMenu , Password, WinScreen};
    Screen currentScreen;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.MainMenu;
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What Whould You Like To Hack?");
        Terminal.WriteLine("Press 1 For Local Library");
        Terminal.WriteLine("Press 2 For Police Station");
        Terminal.WriteLine("Enter Your Choice:");
    }

    void OnUserInput(string input)
    {
        if(input=="menu")
        {
            ShowMainMenu();
        }else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }else if(currentScreen==Screen.Password)
        {
            CheckPassword(input);
        }
       
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1"|| input == "2");
       if (isValidLevel)
        {
            level = int.Parse(input);
            ChooseLevel();
        }
        else
        {
            Terminal.WriteLine("Please Choose valid level");
        }
    }

    void ChooseLevel()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter password");
        switch (level)
        {
            case 1:
                password = Level1Passwords[Random.Range(0, Level1Passwords.Length)];
                break;
            case 2:
                password = Level2Passwords[Random.Range(0, Level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
        
    }

    void CheckPassword(string input)
    {
        if(input==password)
        {
            currentScreen = Screen.WinScreen;
            Terminal.ClearScreen();
            NewMethod();
        }
        else
        {
            Terminal.WriteLine("Please Enter Valid Password");
        }
    }

    void NewMethod()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Welcome To Library");
                Terminal.WriteLine(@"
     _________
    /       // 
   / Book  //
  /       //
 /_______//
(_______(/
                ");
                Terminal.WriteLine("Go Back to Menu Please Enter menu");
                break;
            case 2:
                Terminal.WriteLine("Welcome To Police Station");
                Terminal.WriteLine(@"
      _________________________
    /                         /     
   /       Police Station    /
  /                         /
 /                         /
/_________________________/
");
                Terminal.WriteLine("Go Back to Menu Please Enter menu");
                break;
        }
       
    }
}
