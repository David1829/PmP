
namespace ConsoleApp3
{
    internal class Book
    {
        //Datas
        private string author;
        private string title;
        private int year;
        private int pages;


        // Constructors
        public Book(string author, string title, int year, int pages)
        {
            this.author = author;
            this.title = title;
            this.year = year;
            this.pages = pages;
        }

        // Methods
        public string AllData()
        {
            return $"{author}: {title}, {year} ({pages})";
        }
    }
}
