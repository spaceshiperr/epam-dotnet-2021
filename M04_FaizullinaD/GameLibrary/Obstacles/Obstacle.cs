namespace GameLibrary.Obstacles
{
    public abstract class Obstacle
    {
        private static int _count = 0;

        public Obstacle(Location location)
        {
            Location = location;
            _count++;
        }

        public Location Location { get; set; }

        public static int GetTotalObstaclesCount()
        {
            return _count;
        }
    }
}
