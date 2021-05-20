using GameLibrary.Bonuses;
using GameLibrary.Monsters;
using GameLibrary.Obstacles;
using System.Collections.Generic;
using System;

namespace GameLibrary
{
    public class Field
    {
        private int _width;

        private int _height;
        
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

        public int Width
        {
            get 
            {
                return _width;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(Width) + ": field width must be a positive number");
                
                _width = value;
                if (!Equals(_height, default(int)))
                    Size = _width * _height;

            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(Width) + ": field height must be a positive number");

                _height = value;
                Size = _width * _height;
            }
        }

        public int Size { get; private set; }

        public List<Bonus> Bonuses { get; }

        public List<Obstacle> Obstacles { get; }

        public List<Monster> Monsters { get;  }
    }
}
