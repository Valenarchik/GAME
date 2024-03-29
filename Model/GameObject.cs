﻿using System.Drawing;
using System.Linq;

namespace Model
{
    public abstract class GameObject
    {
        protected readonly Game Game;

        public readonly Size Size;
        public Point Position { get; protected set; }
        public Point ButtonRight => Position + Size;
        public Point Centre => Position + Size/2;

        public double Radius => Game.GetDistance(Centre, Position);

        protected GameObject(Game game, Point position, Size size)
        {
            Game = game;
            Position = position;
            Size = size;
        }
        
        protected bool IsInsideMap() => Game.IsInsideMap(Position) && Game.IsInsideMap(ButtonRight);
    }
}