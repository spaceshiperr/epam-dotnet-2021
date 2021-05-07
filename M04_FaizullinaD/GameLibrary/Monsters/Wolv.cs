using System;

namespace GameLibrary.Monsters
{
    public class Wolv : Monster
    {
        public Wolv(Location location) : base(location) { }

        public override void Move(Field field, Location playerLocation)
        {
            throw new NotImplementedException("An algorithm for how wolves move");
        }
    }
}
