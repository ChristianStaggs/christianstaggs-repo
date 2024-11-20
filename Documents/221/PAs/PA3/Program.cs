using System;
using System.Globalization;
using System.Reflection.Metadata;



int gamesWon = 0;
int gamesLost = 0;


string userInput = GetMenuChoice();
while (userInput != "3")
{
    Route(userInput, ref gamesWon, ref gamesLost);
    userInput = GetMenuChoice();
}

Goodbye(gamesWon, gamesLost);

//************End main*************

static string GetMenuChoice()
{
    DisplayMenu();
    string userInput = Console.ReadLine();

    while (!ValidMenuChoice(userInput))
    {
        Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
        Console.WriteLine("Press any key to continue....");
        Console.ReadKey();

        DisplayMenu();
        userInput = Console.ReadLine();
    }

    return userInput;
}

static void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("1:   Play Snowman");
    Console.WriteLine("2:   See Scoreboard");
    Console.WriteLine("3:   Exit Game");
}

static bool ValidMenuChoice(string userInput)
{
   
    
    bool isValidNumber = int.TryParse(userInput, out int num);

    
    if (isValidNumber && (num == 1 || num == 2 || num == 3))
    {
        return true;
    }
    return false;

}

static void Route(string userInput, ref int gamesWon, ref int gamesLost)
{

     switch(userInput){
        case "1":
            SnowMan(ref gamesWon, ref gamesLost);
            break;
        case "2":
            ScoreBoard(gamesWon, gamesLost);
             break;
        case "3":
             Goodbye(gamesWon, gamesLost);
             break;
        default:
             System.Console.WriteLine("Invalid Choice");;
             break;
    }
}

static void SnowMan(ref int gamesWon, ref int gamesLost)
{
    Console.Clear();
    string word = GetRandomWord();
    char[] displayWord = SetDisplayWord(word);
    int missed = 0;
    string guessed = "";

    while (KeepGoing(displayWord, missed))
    {
        ShowBoard(displayWord, missed, guessed);
        Console.WriteLine();
        try
        {
            char pickedLetter = Console.ReadLine().ToUpper()[0];
            CheckChoice(displayWord, word, ref missed, ref guessed, pickedLetter);
        }
        catch
        {
            Console.WriteLine("Invalid input, please choose at least one character");
            Pause();
        }
        Console.Clear();
    }

    if (missed == 7)
    {
        Console.WriteLine("Sorry you lost");
        gamesLost++;
    }
    else
    {
        Console.WriteLine("You Won!");
        gamesWon++;
    }
    Console.WriteLine("Press any key to continue.....");
    Console.ReadKey();
}

static void CheckChoice(char[] displayWord, string word, ref int missed, ref string guessed, char pickedLetter)
{
   if (LetterInWord(pickedLetter, guessed))
    {
        Console.WriteLine($"You've already guessed '{pickedLetter}'.");
        Pause();
    }
    else
    {
        if (LetterInWord(pickedLetter, word))
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == pickedLetter)
                {
                    displayWord[i] = pickedLetter;
                }
            }
        }
        else
        {
            guessed += pickedLetter;
            missed++;
        }
    }
}

static bool LetterInWord(char letter, string word)
{ 
    for (int i = 0; i<word.Length; i++){
        if(word[i]==letter){
            return true;
        }
    }
    return false;

}

static bool KeepGoing(char[] displayWord, int missed)
{

    if (missed >= 7)
    {
        return false;
    }

    for (int i = 0; i < displayWord.Length; i++)
    {
        if (displayWord[i] == '_')
        {
            return true;
            
        }
    }
    return false;

}

static void ShowBoard(char[] displayWord, int missed, string guessed)
{
    Console.WriteLine("Word to guess: ");
    for (int i = 0; i < displayWord.Length; i++)
    {
        Console.Write(displayWord[i]);
    }

    Console.WriteLine();
    Console.WriteLine("Letters Guessed => " + guessed);

    Console.WriteLine("Currently missed " + missed);

}

static char[] SetDisplayWord(string word)
{

    
    char[] displayWord = new char[word.Length];
    
    for (int i = 0; i < word.Length; i++)
    {
        displayWord[i] = '_'; 
    }

    return displayWord;

}

static string GetRandomWord()
{
    // Calls the GetWordList to retrieve the list of words,
    // chooses a word randomly from the list, and return that word
    string [] word = GetWordList();

    Random rnd = new Random();
   
    return word[rnd.Next(word.Length)];

    }



static string[] GetWordList()
{
    // Step 1: Count the lines in the file
    int wordCount = 0;
    using (StreamReader countFile = new StreamReader("hangman.txt"))
    {
        while (countFile.ReadLine() != null)
        {
            wordCount++;
        }
    }

    // Step 2: Initialize array with the correct size
    string[] words = new string[wordCount];
    
    // Step 3: Populate the array with words from the file
    int index = 0;
    using (StreamReader inFile = new StreamReader("hangman.txt"))
    {
        string line;
        while ((line = inFile.ReadLine()) != null)
        {
            words[index] = line;
            index++;
        }
    }

    return words;
}
static void ScoreBoard(int gamesWon, int gamesLost)
{
    Console.Clear();
    Console.WriteLine("You have won " + gamesWon + " games");
    Console.WriteLine("You have lost " + gamesLost + " games");
    Console.WriteLine("Press any key to continue....");
    Console.ReadKey();
}

static void Goodbye(int gamesWon, int gamesLost)
{
    Console.Clear();
    Console.WriteLine("Thank you for playing... \n" +
        "Press any key for one final look at the scoreboard" +
        " before you go");
    Console.ReadKey();
    ScoreBoard(gamesWon, gamesLost);
}

static void Pause()
{
    System.Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}