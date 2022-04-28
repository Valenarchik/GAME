using System.Drawing;

namespace Game.Model
{
    public class Player:GameEntity
    {
        public Player(GameLevel level, Point position, int speed, Size size) : base(level, position, speed, size)
        {
        }
    }
}
