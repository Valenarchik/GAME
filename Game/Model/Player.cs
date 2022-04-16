using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{

    class Player:Entity
    {
        public bool IsMoving { get;private set; }
        public Player(Point position, Size size) : base(position, size)
        {
        }

        public override void Move(Directions direction)
        {
            IsMoving = true;
            base.Move(direction);
        }

        public void StopMove() => IsMoving = false;
    }
}
