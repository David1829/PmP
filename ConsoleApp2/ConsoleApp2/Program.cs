//Console.WriteLine("Ev: ");
//string input = Console.ReadLine();
//int birthYear = int.Parse(input);

//int currentYear = DateTime.Now.Year;
//int age = currentYear - birthYear;
//Console.WriteLine("In this year you are " + age + " old");
//Console.WriteLine($"In this year you are {age} old");
//Console.WriteLine($"In next year  you turn {age + 1}");

//// ------------
//Console.WriteLine("height: ");
//double height = double.Parse(Console.ReadLine());
//Console.WriteLine("Weight: ");
//double weight = double.Parse(Console.ReadLine());
//double bmi = weight / (height * height);
//Console.WriteLine($"Your bmi is {bmi}");

//Console.WriteLine("Give time in seconds");
//int seconds = int.Parse(Console.ReadLine());

//int minutes = seconds / 60;
//int remain = seconds % 60;

//Console.WriteLine($"The time is: {minutes}:{remain:D2}");

//Console.WriteLine("Give me your password:");
//string jelszo = Console.ReadLine();
//Console.WriteLine("Megegyszer");
//string jelszo2 = Console.ReadLine();

//if (jelszo == jelszo2)
//        {
//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine("egyezik");
//}
//else
//{
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine("Nem egyezik");
//}
//Console.WriteLine("Give me a number");
//int numb = int.Parse(Console.ReadLine());
//Console.WriteLine("Give me another number");
//int numb2 = int.Parse(Console.ReadLine());
//Console.WriteLine("Give me a symbol");
//string symbol = Console.ReadLine();


//if (symbol == "*")
//        {
//    Console.WriteLine($"Number is {numb} {symbol} {numb2} = {numb * numb2}");
//    }
//else if (symbol == "/")
//     {
//    Console.WriteLine($"Number is {numb} {symbol} {numb2} = {numb / numb2}");
//}
//else if (symbol == "+")
//        {
//    Console.WriteLine($"Number is {numb} {symbol} {numb2} = {numb + numb2}");
//    }
//else
//{
//    Console.WriteLine($"Number is {numb} {symbol} {numb2} = {numb - numb2}");
//}


//Console.WriteLine("N = ");
//int n = int.Parse(Console.ReadLine());

//Console.WriteLine("0..N");

//for (int i = 0; i <= n; i++)
//{
//    if (i % 2 == 0)
//    {
//        Console.WriteLine(i + " ");
//    }
//}
//Console.WriteLine("First password");
//string pw = Console.ReadLine();
//string input;
//do
//{
//    Console.WriteLine("Provide password: ");
//    input = Console.ReadLine();
//} while (pw != input);

//Console.WriteLine("Logged in!");

//Console.WriteLine("First password");
//string pw = Console.ReadLine();
//Console.WriteLine("Second password");
//string input = Console.ReadLine();
//int i = 1;
//while (i != 3)
//{


//    if (pw != input)
//    {
//        i += 1;
//        Console.WriteLine("Again");
//        input = Console.ReadLine();
//    }
//    else
//    {
//        Console.WriteLine("Logged in!");
//        break;
//    }
//}
//if (i == 3 )
//{
//    Console.WriteLine("Access denied");
//}
Console.WriteLine("Player number");
int player = int.Parse(Console.ReadLine());

bool found = false;
Random random = new Random();
int winner = 0;
while (!found)
{
    Console.WriteLine("NEW ROUND");
    for (int i = 1; i <= player && !found; i++)
    {
        Console.WriteLine($"{i}. player rolls. Press Enter");
        Console.ReadLine();
        int roll = random.Next(1, 7); // 2. paramaeter is needed +1
        Console.WriteLine($"Roll: {roll}");
        if (roll == 6)
        {
            found = true;
            winner = i;
        }
    }   
    
}

Console.WriteLine("------------------------------");
Console.WriteLine($"{winner}. player starts the game");