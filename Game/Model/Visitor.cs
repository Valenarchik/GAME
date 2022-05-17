using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public class Visitor : GameEntity
    {
        public TypeVisitor TypeVisitor { get; set; }
        public bool OrderAccepted { get; set; } = false;
        public bool OrderIsCompleted { get; set; } = false;
        public LinkedList<Direction> Way { get; private set; } = new();
        public override void Move(Direction direction)
        {
            base.Move(direction);
            if(IsMoving)
                Way.RemoveFirst();
        }

        public Visitor(Game game, Point position, int speed, Size size) : base(game, position, speed, size)
        {
            Sell = MapSell.Visitor;
            var point1 = new Point(520, 475);
            var point2 = new Point(520, 380);
            FindWay(position,point1);
            FindWay(point1,point2);
        }

        public void FindWay(Point start,Point end)
        {
            if (!Game.IsInsideMap(end))
                return;
            var currentY = start.Y;
            while (Math.Abs(currentY - end.Y) > Speed)
            {
                if(currentY > end.Y)
                {
                    Way.AddLast(Direction.Up);
                    currentY -= Speed;
                }
                else
                {
                    Way.AddLast(Direction.Down);
                    currentY += Speed;
                }
            }
            
            var currentX = start.X;
            while (Math.Abs(currentX - end.X) > Speed)
            {
                if(currentX > end.X)
                {
                    Way.AddLast(Direction.Left);
                    currentX -= Speed;
                }
                else
                {
                    Way.AddLast(Direction.Right);
                    currentX += Speed;
                }
            }
        }
    }

    public enum TypeVisitor
    {
        Red,
        Green
    }
}