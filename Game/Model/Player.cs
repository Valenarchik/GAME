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
        public Player(PointF position, float speed, Size size) : base(position, speed, size)
        {
        }
    }
}
