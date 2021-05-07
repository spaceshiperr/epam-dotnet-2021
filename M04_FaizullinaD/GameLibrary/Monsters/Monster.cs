namespace GameLibrary.Monsters
{
    public abstract class Monster
    {
        private static int _count = 0;

        public Monster(Location location)
        {
            Location = location;
            _count++;
        }

        public Location Location { get; set; }

        public abstract void Move(Field field, Location playerLocation);

        public static int GetCount()
        {
            return _count;
        }
    }
}
