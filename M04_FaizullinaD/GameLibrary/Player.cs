using GameLibrary.Bonuses;

namespace GameLibrary
{
    public class Player
    {
        public Player(string name, string id)
        {
            Name = name;
            ID = id;
        }

        public string Name { get; set; }

        public string ID { get; }

        public int Score { get; set; }

        public Location Location { get; set; }

        public void Move(Location endLocation)
        {
            Location = endLocation;
        }

        public void PickUpBonus(Bonus bonus)
        {
            bonus.IsPickedUp = true;
            Score += bonus.Points;
        }
    }
}
