using System.Drawing;

namespace Game
{
    public abstract class Entity
    {
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
                    break;
                case Directions.Down:
                    Position = new PointF(Position.X, Position.Y + 1.5f);
                    break;
                case Directions.Right:
                    Position = new PointF(Position.X + 1.5f, Position.Y );
                    break;
                case Directions.Left:
                    Position = new PointF(Position.X-1.5f, Position.Y);
                    break;
            }
        }
    }
}