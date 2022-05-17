using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace Game.Model
{
    public abstract class GameObject
    {
        protected MapSell Sell;
        protected readonly Game Game;

        public readonly Size Size;
        public Point Position { get; protected set; }
        public Point ButtonRight => Position+Size;
        public Point Centre => Position+Size/2 ;

        public IEnumerable<Point> Perimeter()
        {
            var buttonRight = ButtonRight;
            for (var i = Position.X; i <= buttonRight.X; i += 2)
            {
                yield return new Point(i, Position.Y);
                yield return new Point(i, buttonRight.Y);
            } 
            for (var i = Position.Y; i <= buttonRight.Y; i += 2)
            {
                yield return new Point(Position.X,i);
                yield return new Point(buttonRight.X,i);
            }
        }

        public double Radius => Game.GetDistance(Centre, Position);

        protected GameObject(Game game, Point position, Size size)
        {
            Game = game;
            Position = position;
            Size = size;
        }

        protected bool IsCollision() => Game.Objects
            .Where(x => !x.Equals(this))
            .Any(IsCollision);

        private bool IsCollision(GameObject o)
        {
            return Game.SegmentsIntersected(Position.X, Position.X + Size.Width,
                       o.Position.X, o.Position.X + o.Size.Width)
                   && Game.SegmentsIntersected(Position.Y, Position.Y + Size.Height,
                       o.Position.Y, o.Position.Y + o.Size.Height);
        }


        protected bool IsInsideMap() => Game.IsInsideMap(Position) && Game.IsInsideMap(ButtonRight);
    }
}