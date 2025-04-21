using System;
using System.Diagnostics;

namespace LexiconÖvning4;

/*
Frågor:
1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess
grundläggande funktion
Stacken kan liknas vid en stapel av objekt, för att nå en viss position i stacken måste du först lyfta bort de objekt som ligger över den i stapeln. 
Dessa objekt kan lagra någon form av data, exempelvis kan ett objekt i stacken vara en variabel x som lagrar en int med värdet 1.
Stacken har koll på vilka anrop och metoder som exekveras. När ett anrop eller en metod är färdigt med att exekveras kastas det automatiskt. Därmed är stacken självunderhållande. 

Heapen är en datastruktur som kan liknas vid ett träd. För att nå ett visst objekt på trädet måste vi veta dess position. Detta gör vi genom att lagra en adress i stacken. 
När vi vill nå ett objekt i heapen går man då först til stacken för att hitta dess adress och sedan till heapen med adressen. 
Den används främst för större datalagring då stacken skulle snabbt bli en väldigt hög stapel om allt lagrades på stacken. 
Detta skulle sakta ner programmet eftersom det då finns mer data som behöver gås igenom för att hitta rätt i stacken.
Heapen har ingen information om exekveringsordning och kan därför inte automatiskt kasta data som är färdigexekverad. 
Därför existerar det i C# en garbage collector som suksesivt automatiskt går igenom heapen och kastar sådant vi inte längre behöver.

2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
Value type är värden som lagras i stacken. De är likt en låda som innehåller ett värde.

Referens type är värden som lagras i heapen. När vi deklarerar en variabel av en reference type innehåller den variabeln inte några av dess faktiska information. Istället innehåller den en adress i heapen som informationen faktiskt lagras i.


3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den
andra returnerar 4, varför?

Den första returnerar 3 då x i metod 1 är en value type. när vi skapar y i metod 1 skapar vi en ny variabel med ett eget värde som i kodraden "y = x" kopierar värdet i x och sparar samma värde i y. 
Därför påverkas inte x av att vi sedan lagrar värdet 4 i y.

I metod 2 är x istället en reference type. När vi sätter y = x i metod 2 kopierar vi samma minnesadress till y som vi har lagrat i x. Därför är det samma minnesadress vi når när vi kallar på x.MyValue som y.MyValue. 
Därför uppdateras även värdet x.MyValue om vi uppdaterar y.MyValue, eftersom dom faktiskt är samma värde.   
 
 */
class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    static void ExamineList()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */


        /* 
         Övning 1: Examine list
        När öker listans kapacitet?
        När den underliggande arrayen är full och vi försöker lägga till ytterliggare element i den.

        Med hur mycket ökar den?
        Först gå den från 0 till 4 i storlek, därefter dubleras arrayens storlek.

        Varför ökar inte listan med samma takt som element läggs till?
        Detta skulle kräva extra processorkraft varje gång ett nytt element läggs till och programmet skulle då köras långsammare. Genom att duplicera listan så sparar man processorkraft på bekostnad av datorns minne. 

        Minskar kapaciteten när element tas bort ur listan?
        Nej

        När är det fördelaktigt att använda en egendefinierad array istället för en lista?
        När vi vet exakt hur många element som kommer behöva lagras.
         
         */
        List<string> theList = new List<string>();
        bool returnToMainMeny = false;
        const string Message = "Start your input with '+' to add element to list, '-' to remove element from the list and '0' to return to main menu";
        Console.WriteLine(Message);
        do
        {
            Console.WriteLine(theList.Count());
            Console.WriteLine(theList.Capacity);

            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);
            switch (nav)
            {

                case '+':
                    theList.Add(value);
                    break;
                case '-':
                    theList.Remove(value);
                    break;
                case '0':
                    returnToMainMeny = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    Console.WriteLine(Message);
                    break;
            }
        }
        while (!returnToMainMeny);



    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */
        Queue<string> theQueue = new Queue<string>();
        bool returnToMainMeny = false;
        const string Message = "Start your input with '+' to add element to que, '-' to deque and '0' to return to main menu";
        Console.WriteLine(Message);
        do
        {
            Console.WriteLine("Current Queue:");
            foreach (string word in theQueue)
            {
                Console.WriteLine($"{word}");
            }
            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1);
            switch (nav)
            {

                case '+':
                    theQueue.Enqueue(value);
                    break;
                case '-':
                    theQueue.Dequeue();
                    break;
                case '0':
                    returnToMainMeny = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, try again");
                    Console.WriteLine(Message);
                    break;
            }
        }
        while (!returnToMainMeny);
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
    {
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */


        Stack<char> stack = new Stack<char>();
        const string Message = "Input a message that you would like me to reverse the order of the words in:";
        Console.WriteLine(Message);
        string input = Console.ReadLine();
        foreach (char c in input)
        {
            stack.Push(c);
        }
        string ansString = "";
        while (stack.Count() > 0)
        {
            ansString += stack.Pop();
        }
        Console.WriteLine(ansString);

    }

    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */
        Console.WriteLine("Enter a string that to check validity of:");
        Console.WriteLine($"The string {(IsValid(Console.ReadLine()) ? "is" : "isn't")} well formed.");
    }
    static public bool IsValid(string stringToCheck)
    {
        string checkstring = "(){}[]";
        string strippedString = "";
        foreach (char c in stringToCheck)
        {
            if (checkstring.Contains(c))
            {
                strippedString += c;
            }
        }
        bool sIsValid = false;
        while (strippedString.Length > 0)
        {
            for (int i = 0; i < strippedString.Length; i++)
            {
                if (strippedString[i] == checkstring[1] | strippedString[i] == checkstring[3] | strippedString[i] == checkstring[5])
                {
                    if (i == 0) { return sIsValid; }
                    if ((strippedString[i] == checkstring[1] && strippedString[i - 1] == checkstring[0]) | (strippedString[i] == checkstring[3] && strippedString[i - 1] == checkstring[2]) | (strippedString[i] == checkstring[5] && strippedString[i - 1] == checkstring[4]))
                    {
                        strippedString = strippedString.Remove((i - 1), 2);
                        break;
                    }
                    else
                    {
                        sIsValid = false;
                        return sIsValid;
                    }

                }
                else if (i + 1 == strippedString.Length) { return sIsValid; }

            }
            if (strippedString.Length == 0)
            {
                sIsValid = true;
                return sIsValid;
            }

        }
        return sIsValid;

    }
}



