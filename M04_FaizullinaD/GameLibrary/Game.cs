using System;

namespace GameLibrary
{
    public class Game
    {
        public Field Field { get; }

        public Player Player { get; }

        public int Score { get; set; }

        public Game(Field field, Player player)
        {
            Field = field;
            Player = player;
        }

        public void Play()
        {
            while (true)
            {
                var endLocation = GetNewLocation(Field);
                Player.Move(endLocation);
            }
        }

        private Location GetNewLocation(Field field)
        {
            throw new NotImplementedException("Get user input location");
        }
    }
}
