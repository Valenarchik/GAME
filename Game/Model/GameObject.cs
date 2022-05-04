using System;
using System.Drawing;

namespace Game.Model
{
    public abstract class GameObject
    {
        protected readonly Game Game;
        public Point Position { get; protected set; }
        public readonly Size Size;
        public Point Centre => Position+Size/2;
        
        
        public double Radius => Game.GetDistance(Centre, Position);

        protected GameObject(Game game, Point position, Size size)
        {
            Game = game;
            Position = position;
            Size = size;
        }

        protected bool IsCollision(GameObject another)
        {
            return Game.SegmentsIntersected(Position.X, Position.X + Size.Width, another.Position.X,
                       another.Position.X + another.Size.Width)
                   && Game.SegmentsIntersected(Position.Y, Position.Y + Size.Height, another.Position.Y,
                       another.Position.Y + another.Size.Height);
        }

        protected bool IsInsideMap() => Game.IsInsideMap(Position) && Game.IsInsideMap(Position + Size);
    }
}