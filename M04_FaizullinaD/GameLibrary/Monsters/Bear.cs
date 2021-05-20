using System;

namespace GameLibrary.Monsters
{
    public class Bear : Monster
    {
        public Bear(Location location) : base(location) { }

        public override void Move(Field field, Location playerLocation)
        {
            throw new NotImplementedException("An algorithm for how bears move");
        }
    }
}
