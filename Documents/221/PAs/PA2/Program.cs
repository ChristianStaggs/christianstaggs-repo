//Main

DisplayMenu();
string userInput = ""; 
userInput = GetUserChoice();
RouteEm(userInput);



//End Main

static void DisplayMenu(){
    Console.Clear();
    System.Console.WriteLine("[1] Convert Units of Measurement\n[2] Rock Classification\n[3] Exit");
}

static string GetUserChoice(){
    return Console.ReadLine();
}

static void RouteEm(string userChoice){
    switch(userChoice){
        case "1":
            Conversion();
            break;
        case "2":
            RockClassification();
             break;
        case "3":
             Cya();
             break;
        default:
             TrashInput();
             break;
    }
}

static void Conversion(){
    System.Console.WriteLine("in C");
}

static void RockClassification(){
    System.Console.WriteLine("in R");
}

static void Cya(){
    System.Console.WriteLine("Cya later alligator");
}

static void TrashInput(){
    System.Console.WriteLine("Invalid Input");
}