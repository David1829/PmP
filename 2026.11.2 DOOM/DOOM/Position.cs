namespace DOOM
{
    internal class Position
    {
        public int X
        {  set; get; }
        public int Y {  set; get; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position Add(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static double Distance(Position p1, Position p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
