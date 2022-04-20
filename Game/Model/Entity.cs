using System.Drawing;

namespace Game
{
    public abstract class Entity
    {
        public float Speed { get; private set; }
        public Directions Direction { get; private set; }
        public bool IsMoving { get;private set; }
        public PointF Position { get; private set; }
        public readonly Size Size;


        protected Entity(PointF position, float speed, Size size)
        {
            Size = size;
            Speed = speed;
            Position = position;
        }
        public virtual void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up:
                    Position = new PointF(Position.X, Position.Y -Speed);
                    Direction = Directions.Up;
                    break;
                case Directions.Down:
                    Position = new PointF(Position.X, Position.Y + Speed);
                    Direction = Directions.Down;
                    break;
                case Directions.Right:
                    Position = new PointF(Position.X + Speed, Position.Y );
                    Direction = Directions.Right;
                    break;
                case Directions.Left:
                    Position = new PointF(Position.X - Speed, Position.Y);
                    Direction = Directions.Left;
                    break;
            }
            IsMoving = true;
        }
        public void StopMove() => IsMoving = false;
    }
}