// 9. labor, The Console Slayer: egy hely a pályán (x: oszlop, y: sor)
namespace ConsoleSlayer
{
    internal class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // A feladat szerint kívülről olvasható és írható is.
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // Statikus metódus: nem egy pozícióhoz tartozik, hanem az osztályhoz, ezért így hívjuk:
        // Position.Add(p1, p2), mint a Math.Sqrt-ot. Egyik paramétert sem módosítja, új pozíciót ad vissza.
        public static Position Add(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        // Euklideszi távolság, vagyis a két pontot összekötő szakasz hossza (Pitagorasz-tétel).
        // A szomszédos csempe 1, az átlós szomszéd kb. 1,41 távolságra van.
        public static double Distance(Position p1, Position p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // A feladat nem kéri, de a kiírást megkönnyíti (8. labor): Console.WriteLine(p) "(3, 4)" alakot ír.
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
