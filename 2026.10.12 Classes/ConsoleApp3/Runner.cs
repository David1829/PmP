namespace ConsoleApp3
{
    internal class Runner
    {
        private string name;
        private int number;
        private double speed;
        private double distance;

        
        public Runner(string name, int number, double speed)
        {
            this.name = name;
            this.number = number;
            this.speed = speed;
            distance = 0;
        }
        public void refreshDistance(int seconds)
        {
            distance += speed * seconds;

        }
        public void Show()
        {
            Console.SetCursorPosition((int)distance, number);
            Console.Write(name[0]);
        }
        public double GetDistance()
        {
            return distance;
        }
    }

}
