namespace GameLibrary
{
    public class Location
    {
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }

        public bool Equals(Location other)
        {
            return other != null && other.X == X && other.Y == Y;
        }
        
        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}
