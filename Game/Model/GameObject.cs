using System;
using System.Drawing;

namespace Game.Model
{
    public abstract class GameObject
    {
        protected readonly GameLevel Level;
        public Point Position { get; protected set; }
        public readonly Size Size;

        protected GameObject(GameLevel level, Point position, Size size)
        {
            Level = level;
            Position = position;
            Size = size;
        }

        protected bool IsCollision(GameObject another)
        {
            return SegmentsIntersected(Position.X, Position.X + Size.Width, another.Position.X,
                       another.Position.X + another.Size.Width)
                   && SegmentsIntersected(Position.Y, Position.Y + Size.Height, another.Position.Y,
                       another.Position.Y + another.Size.Height);
        }

        private static bool SegmentsIntersected(float r1Min, float r1Max, float r2Min, float r2Max) =>
            Math.Min(r1Max, r2Max) >= Math.Max(r1Min, r2Min);

        protected bool IsInsideMap() => Level.IsInsideMap(Position) && Level.IsInsideMap(Position + Size);
    }

    public enum Type
    {
        Player,
        Furnace,
        Interior
    }
}