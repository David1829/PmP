//using System.ComponentModel.Design;

//string path = "color.txt";

//string[] lines = File.ReadAllLines(path);
//foreach (string line in lines)
//{
//    string[] parts = line.Split('#');

//    for (int i = 0; i < parts.Length; i++)
//    {
//        if (parts[i] == "Red")
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//        }
//        else if (parts[i] == "Blue")
//        {
//            Console.ForegroundColor = ConsoleColor.Blue;
//        }
//        else if (parts[i] == "Green")
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//        }
//    }
//    Console.WriteLine(parts[1]);
//    Console.ForegroundColor= ConsoleColor.White;
//}
//string filename = "lottery.txt";

//StreamWriter writer = new StreamWriter(filename);

//Random random = new Random();
//string answer;
//DateTime today = DateTime.Today;
//do
//{ 
//    List<int> numbers = new List<int>();
//    while (numbers.Count < 5)
//    {
//        int number = random.Next(1, 91);
//        if (!numbers.Contains(number))
//        {
//            numbers.Add(number);
//        }

//    }


//    Console.Write($"On {today:yyyy. MM. dd.} numbers were: ");
//    writer.Write($"On {today:yyyy. MM. dd.} numbers were: ");
//    foreach (int number in numbers)
//    {
//        Console.Write(number + " ");
//        writer.Write(number + " ");
//    }
//    answer = Console.ReadLine();
//    today=today.AddDays(7);
//    writer.WriteLine();
//} while (answer == "y") ;
//writer.Close();

StreamReader reader = new StreamReader("NHANES_1999-2018.csv");

List<int> SEQN = new List<int>();
List<string> SURVEY = new List<string>();
List<int> RIAGENDR = new List<int>();
List<int> RIDAGEYR = new List<int>();
List<double> BMXBMI = new List<double>();
List<double> LBDGLUSI = new List<double>();

reader.ReadLine();

while (!reader.EndOfStream)
{
    string line = reader.ReadLine();

    string[] parts = line.Split(",");
    SEQN.Add(int.Parse(parts[0]));
    SURVEY.Add(parts[1]);
    RIAGENDR.Add((int)double.Parse(parts[2]));
    RIDAGEYR.Add((int)double.Parse(parts[3]));
    BMXBMI.Add(double.Parse(parts[4]));
    LBDGLUSI.Add(double.Parse(parts[5]));
}
Console.WriteLine("Year of survey");
string survey = Console.ReadLine();
double maleBmiSum = 0;
double femaleBiSum = 0;
int maleCount = 0;
int femaleCount = 0;

for (int i = 0; i < BMXBMI.Count; i++)
{
    if (SURVEY[i] == survey)
    {
        if (RIAGENDR[i] == 1)
        {
            maleCount++;
            maleBmiSum += BMXBMI[i];
        }
        else
        {
            femaleCount++;
            femaleBiSum += BMXBMI[i];
        }
    }
}
Console.WriteLine($"Avrage BMI woman: {femaleBiSum/femaleCount:f2}\nAvrage BMI man: {maleBmiSum/maleCount:f2}");

double diabetes = 0;
double surveycount = 0;
for (int i = 0; i < LBDGLUSI.Count; i++)
{
    if (SURVEY[i] == survey)
    {
        surveycount++;
        if (LBDGLUSI[i] > 5.6)
        {
            diabetes++;
        }
    }
}

Console.WriteLine($"The blood sugar is higher than 5.6 for {diabetes/surveycount*100:f2}% people in year {survey}");


int maxBmiIndex = 0;

for (int i = 0; i < LBDGLUSI.Count; i++)
{
    if (BMXBMI[i] > maxBmiIndex)
    {
        maxBmiIndex = i;
    }
}

Console.WriteLine($"The max BMI index is {BMXBMI[maxBmiIndex]} and the sugar level is {LBDGLUSI[maxBmiIndex]}");


double dagadtCount = 0;
double dagadtKor = 0;

for (int i = 0; i < BMXBMI.Count; i++)
{
    if (BMXBMI[i] >= 30)
    {
        dagadtCount++;
        dagadtKor += RIDAGEYR[i];
    }
}
Console.WriteLine($"The avrage age over 30 BMI is {dagadtKor / dagadtCount:f2}");