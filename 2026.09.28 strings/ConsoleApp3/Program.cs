//Console.WriteLine("Give me a text ");
//string input = Console.ReadLine();
//string noChar = null;
//string reversed = null;
//foreach (char c in input)
//{
//    if (char.IsLetterOrDigit(c))
//    {
//        noChar += char.ToLower(c);
//    }
//}
//for (int i = noChar.Length-1; i >= 0; i--)
//{
//    reversed += noChar[i];
//}    

//if (reversed == noChar)
//{
//    Console.WriteLine("It is palindrom");
//}
//else
//{
//    Console.WriteLine("It is not palindrom");
//}
//Console.WriteLine(noChar);
//Console.WriteLine(reversed);

//Console.WriteLine("Give a license number ");
//string licensePlate = Console.ReadLine();
//string cleanedPlate = null;
//string realPlate = null;


//foreach (char c in licensePlate)
//{
//    if (char.IsLetterOrDigit(c))
//    {
//        cleanedPlate += char.ToUpper(c);
//    }
//}

//bool isValid = cleanedPlate.Length == 7;
//for (int i = 0; i < cleanedPlate.Length && isValid; i++)
//{
//    if (i < 4)
//    {
//        if (!char.IsLetter(cleanedPlate[i]))
//        {
//            isValid = false;
//        }
//    }
//    else
//    {
//        if (!char.IsDigit(cleanedPlate[i]))
//        {
//            isValid = false;
//        }
//    }
//}


//if (isValid)
//{
//    realPlate += cleanedPlate.Substring(0, 2);
//    realPlate += " ";
//    realPlate += cleanedPlate.Substring(2, 2);
//    realPlate += "-";
//    realPlate += cleanedPlate.Substring(4, 3);
//}
//Console.WriteLine(realPlate);

//Console.WriteLine("Give me a NEPTUN code: ");
//string input = Console.ReadLine().Trim().ToUpper();

//if (input.Length != 6)
//{
//    Console.WriteLine("It is not a NEPTUN code!");
//}

//string generated = null;
//Random random = new Random();
//bool notmy = true;
//int count = 0;
//do
//{
//    char first = (char)random.Next('A', 'Z' + 1);
//    generated = first.ToString();
//    for (int i = 0; i < 6; i++)
//    {
//        bool isLetter = random.Next(0, 2) == 0;
//        if (isLetter)
//            generated += (char)random.Next('A', 'Z' + 1);
//        else
//        {
//            generated += (char)random.Next('0', '9' + 1);
//        }
//    }
//    count += 1;
//} while (generated != input);

//Console.WriteLine($"Your NEPTUN code is founded at {count}");

string text = "Vincent;Vega;Vince\nMarsellus;Wallace;Big Man\nWinston;Wolf;The Wolf";

string[] rows = text.Split('\n');
string[,] table = new string[rows.Length, rows[0].Split(';').Length];
for (int i = 0; i < rows.Length; i++)
{
    string[] columns = rows[i].Split(';');
    for (int j = 0; j < columns.Length; j++)
    {
        table[i, j] = columns[j];
    }
}

for (int i = 0;i < table.GetLength(0); i++)
{
    for (int j= 0;j < table.GetLength(1); j++)
    {
        Console.Write($"{table[i,j]} |");
    }
}