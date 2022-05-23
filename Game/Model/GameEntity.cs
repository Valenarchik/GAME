using System.Drawing;
using System.Linq;

namespace Game.Model
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
            var offset = new Size(0, 0);
            switch (direction)
            {
                case Direction.Up:
                    offset = new Size(0, -Speed);
                    Direction = Direction.Up;
                    break;
                case Direction.Down:
                    offset = new Size(0, Speed);
                    Direction = Direction.Down;
                    break;
                case Direction.Right:
                    offset = new Size(Speed, 0);
                    Direction = Direction.Right;
                    break;
                case Direction.Left:
                    offset = new Size(-Speed, 0);
                    Direction = Direction.Left;
                    break;
            }

            Position += offset;
            IsMoving = true;
            if (IsInsideMap() && !IsCollision()) return;
            Position -= offset;
            IsMoving = false;
        }
        public void StopMove() => IsMoving = false;
    }
}