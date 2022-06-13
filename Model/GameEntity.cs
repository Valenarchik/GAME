using System;
using System.Drawing;
using System.Linq;

namespace Model
{
    public abstract class GameEntity : GameObject
    {
        public readonly int Speed;
        public Direction Direction { get; private set; }
        public bool IsMoving { get; private set; }

        protected GameEntity(Game game, Point position, int speed, Size size)
            : base(game, position, size)
        {
            Speed = speed;
        }

        public virtual void Move(Direction direction)
        {
            Direction = direction;
            var offset = direction switch
            {
                Direction.Up => new Size(0, -Speed),
                Direction.Down => new Size(0, Speed),
                Direction.Right => new Size(Speed, 0),
                Direction.Left => new Size(-Speed, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

            Position += offset;
            IsMoving = true;
            if (IsInsideMap() && !IsCollision()) return;
            Position -= offset;
            IsMoving = false;
        }
        
        protected virtual bool IsCollision() => Game.Objects
            .Where(x => !x.Equals(this))
            .Any(IsCollision);
        
        protected bool IsCollision(GameObject o)
        {
            return Game.SegmentsIntersected(Position.X, Position.X + Size.Width,
                       o.Position.X, o.Position.X + o.Size.Width)
                   && Game.SegmentsIntersected(Position.Y, Position.Y + Size.Height,
                       o.Position.Y, o.Position.Y + o.Size.Height);
        }

        public void StopMove() => IsMoving = false;
    }
}