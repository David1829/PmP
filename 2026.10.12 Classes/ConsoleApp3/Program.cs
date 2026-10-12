namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Book b = new Book("The Hobbit - or There and Back Again", "J.R.R. Tolkien", 1937, 312);
            //Console.WriteLine(b.AllData());
            //Book b2 = new Book("Rowling", "Frankeintesndoand", 2026, 123);
            //Console.WriteLine(b2.AllData());
            Runner futosMaca = new Runner("Futos Maca", 1, 3.4);
            Runner setaloRita = new Runner("Setalo Rita", 2, 1.6);

            int stepSeconds = 1;

            int finish = 60;

            do
            {
                Console.Clear();
                futosMaca.refreshDistance(stepSeconds);
                Console.SetCursorPosition(finish, 1);
                Console.Write("|");
                setaloRita.refreshDistance(stepSeconds);
                Console.SetCursorPosition(finish, 2);
                Console.Write("|");

                futosMaca.Show();
                setaloRita.Show();
                Thread.Sleep(100);
            } while (futosMaca.GetDistance() < finish && setaloRita.GetDistance() < finish);
        }
    }
}
