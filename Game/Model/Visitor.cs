using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public class Visitor : GameEntity
    {
        public readonly TypeVisitor TypeVisitor;
        public readonly Pizza WantPizza;
        public bool OrderIsActivated { get; private set; }
        public bool OrderAccepted { get; set; }
        public bool OrderIsCompleted { get; set; }
        private bool iGoToBar;
        private bool iGoToExit;
        public bool Out { get; set; }

        public readonly LinkedList<Direction> Track = new();
        public override void Move(Direction direction)
        {
            base.Move(direction);
            if(IsMoving)
                Track.RemoveFirst();
            if (Track.Count != 0) return;
            if(iGoToBar)
            {
                OrderIsActivated = true;
                iGoToBar = false;
            };
            if (iGoToExit)
            {
                Out = true;
                iGoToExit = false;
            }
        }

        public Visitor(Game game, Point position, int speed, Size size) : base(game, position, speed, size)
        {
            TypeVisitor = (TypeVisitor) Game.Random.Next(0, 2);
            WantPizza = (Pizza) Game.Random.Next(0, 4);
        }

        public void GoToBar()
        {
            FindTrack(Position, new Point(419, 460), new Point(515, 460), new Point(515, 380));
            iGoToBar = true;
        }

        public void GoToExit()
        {
            FindTrack(new Point(515, 380), new Point(456, 380), new Point(456, 432), new Point(379, 432), new Point(379, 684));
            iGoToExit = true;
        }
        
        private void FindTrack(params Point[] track)
        {
            if(track is null || track.Length < 2)
                return;
            for (var i = 1; i < track.Length; i++)
                FindTrack(track[i-1],track[i]);
            
        }
        private void FindTrack(Point start,Point end)
        {
            if (!Game.IsInsideMap(end)) return;
            var currentY = start.Y;
            while (Math.Abs(currentY - end.Y) > Speed)
            {
                if(currentY > end.Y)
                {
                    Track.AddLast(Direction.Up);
                    currentY -= Speed;
                }
                else
                {
                    Track.AddLast(Direction.Down);
                    currentY += Speed;
                }
            }
            
            var currentX = start.X;
            while (Math.Abs(currentX - end.X) > Speed)
            {
                if(currentX > end.X)
                {
                    Track.AddLast(Direction.Left);
                    currentX -= Speed;
                }
                else
                {
                    Track.AddLast(Direction.Right);
                    currentX += Speed;
                }
            }
        }
    }
}