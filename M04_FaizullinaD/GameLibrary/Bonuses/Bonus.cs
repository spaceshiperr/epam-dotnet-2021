namespace GameLibrary.Bonuses
{
    public abstract class Bonus
    {
        private static int _count = 0;

        public Bonus(int points, Location location)
        {
            Points = points;
            Location = location;
            _count++;
        }

        public bool IsPickedUp { get; set; }

        public Location Location { get; set; }

        public int Points { get; }

        public static int GetCount()
        {
            return _count;
        }
    }
}
