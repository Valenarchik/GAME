using System.Drawing;

namespace Game
{
    public abstract class Entity
    {
        public Directions Direction { get; private set; }
        public bool IsMoving { get;private set; }
        public PointF Position { get; private set; }
        public readonly Size Size;
        //public readonly Image Sprite;

        protected Entity(PointF position,Size size)
        {
            Size = size;
            Position = position;
        }
        public virtual void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    Position = new PointF(Position.X, Position.Y - 1.5f);
                    Direction = Directions.Up;
                    break;
                case Directions.Down:
                    Position = new PointF(Position.X, Position.Y + 1.5f);
                    Direction = Directions.Down;
                    break;
                case Directions.Right:
                    Position = new PointF(Position.X + 1.5f, Position.Y );
                    Direction = Directions.Right;
                    break;
                case Directions.Left:
                    Position = new PointF(Position.X-1.5f, Position.Y);
                    Direction = Directions.Left;
                    break;
            }
            IsMoving = true;
        }
        public void StopMove() => IsMoving = false;
    }
}