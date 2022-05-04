using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public abstract class GameEntity : GameObject
    {
        public int Speed { get; set; }
        public Directions Direction { get; private set; }
        public bool IsMoving { get; private set; }

        protected GameEntity(Game game, Point position, int speed, Size size)
            : base(game, position, size)
        {
            Speed = speed;
        }

        public virtual void Move(Directions direction)
        {
            var offset = new Size(0, 0);
            switch (direction)
            {
                case Directions.Up:
                    offset = new Size(0, -Speed);
                    Direction = Directions.Up;
                    break;
                case Directions.Down:
                    offset = new Size(0, Speed);
                    Direction = Directions.Down;
                    break;
                case Directions.Right:
                    offset = new Size(Speed, 0);
                    Direction = Directions.Right;
                    break;
                case Directions.Left:
                    offset = new Size(-Speed, 0);
                    Direction = Directions.Left;
                    break;
            }

            Position += offset;
            if (!IsInsideMap() || Game.Objects
                    .Where(x=>!x.Equals(this))
                    .Any(IsCollision))
                Position -= offset;
            IsMoving = true;
        }

        public void StopMove() => IsMoving = false;
    }
}