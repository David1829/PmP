//Console.Write("N = ");
//int n = int.Parse(Console.ReadLine());

//if (n % 2 == 0)
//{
//    Console.WriteLine("The nubmer is even!");
//}
//else
//{
//    Console.WriteLine("The number is odd!");
//}

//// Valodi osztok
//int divCount = 0;
//for (int i = 2; i < n; i++)
//{
//    if (n % i ==0)
//    {
//        divCount += 1;
//    }
//}
//Console.WriteLine($"Number {n} have {divCount} divisor");
//if (n < 2)
//{
//    Console.WriteLine("None of them");
//}
//else if (divCount == 0)
//{
//    Console.WriteLine("The number is prime");
//}
//else
//{
//    Console.WriteLine("Composite number");
//}

//using System.Numerics;

//Console.WriteLine("Give me a number");
//int number = int.Parse(Console.ReadLine());
//BigInteger fact = number;
//for (int i = number-1; i > 0; i--)
//{
//    fact = fact * i;
//}
//Console.WriteLine($"The fact of {number}! = {fact}");



//string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
//string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
//string[] deck = new string[suits.Length * ranks.Length];
//int deckIndex = 0;
//for (int i = 0; i < suits.Length; i++)
//{
//    for (int j = 0; j < ranks.Length; j++)
//    {
//        deck[deckIndex] = $"{suits[i]} {ranks[j]}";
//    }
//}
//for (int i = 0; i < deck.Length; i++)
//{
//    Console.WriteLine(deck[i]);
//}
//Random random = new Random();

//string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
//string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
//string[] deck = new string[suits.Length * ranks.Length];
//int deckIndex = 0;
//for (int i = 0; i < suits.Length; i++)
//{
//    for (int j = 0; j < ranks.Length; j++)
//    {
//        deck[deckIndex] = $"{suits[i]} {ranks[j]}";
//    }
//}
//for (int i = 0; i < deck.Length; i++)
//{
//    int rand = random.Next(i, deck.Length);

//    //Swap:
//    string temp = deck[i];
//    deck[i] = deck[rand];
//    deck[rand] = temp;
//}
//for (int i = 0; i < deck.Length; i++)
//{
//    Console.WriteLine(deck[i]);
//}

//Console.WriteLine("Give a number ");
//int number = int.Parse(Console.ReadLine());
//string[] strings = new string[number];

//for (int i = 0; i < strings.Length; i++)
//{
//    Console.WriteLine("Give me a word ");
//    string word = Console.ReadLine();
//    strings[i] = $"{word}";
//}
//Console.WriteLine("Give me a test word");
//string secondWord = Console.ReadLine();
//bool benne = true;
//int where = 0;
//for (int i = 0; i < strings.Length; i++)
//{
//    if (strings[i] == secondWord)
//    {
//        benne = true;
//        where = i;
//        break;
//    }
//    else
//        benne = false;
//}

//if (benne)
//{
//    Console.WriteLine($"There is your word in the list on place {where+1}");
//}
//else
//{
//    Console.WriteLine("Your word not in the list");
//}


using System.Reflection.Metadata.Ecma335;

List<string> names = new List<string>();
List<int> ages = new List<int>();
List<bool> progs = new List<bool>();
bool con = true;
do
{
    Console.WriteLine("Give the datas of the peoples, to end write nothing to name");
    Console.WriteLine("Name: ");
    string name = Console.ReadLine();
    if (name == "")
    {
        con = false;
    }
    else
    {
        Console.WriteLine("Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Have experience? y/n ");
        string answer = Console.ReadLine();
        bool prog = answer == "y";

        names.Add(name);
        ages.Add(age);
        progs.Add(prog);
    }
} while (con);
int sum = 0;
foreach (int age in ages)
{
    sum += age;
}
double average = (double)sum / ages.Count;
Console.WriteLine($"Average age: {average}");

int noprogsum = 0;
int noprogcount = 0;
for (int i = 0; i < ages.Count(); i++)
{
    if (progs[i] == false)
    {
        noprogsum += ages[i];
        noprogcount += 1;
    }
}
double noprogaverage = (double)noprogsum / noprogcount;
Console.WriteLine($"The avrage of not programming age are {noprogaverage}");

int mostoldindex = 0;

for (int i = 0; i < ages.Count(); i++)
{
    if (progs[i] == true && ages[i] > ages[mostoldindex])
    {
        mostoldindex = i;
    }
}
Console.WriteLine($"Most old name: {names[mostoldindex]}");
Console.WriteLine($"Most old age: {ages[mostoldindex]}");