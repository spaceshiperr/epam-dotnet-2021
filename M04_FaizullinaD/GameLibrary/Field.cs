using GameLibrary.Bonuses;
using GameLibrary.Monsters;
using GameLibrary.Obstacles;
using System.Collections.Generic;

namespace GameLibrary
{
    public class Field
    {
        public Field(int width, 
                     int height,
                     List<Bonus> bonuses,
                     List<Obstacle> obstacles,
                     List<Monster> monsters)
        {
            Width = width;
            Height = height;
            Size = width * height;
            Bonuses = bonuses;
            Obstacles = obstacles;
            Monsters = monsters;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Size { get; }

        public List<Bonus> Bonuses { get; }

        public List<Obstacle> Obstacles { get; }

        public List<Monster> Monsters { get;  }
    }
}
