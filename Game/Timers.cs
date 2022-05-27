using System;
using System.Drawing;
using System.Linq;
using Model;
using System.Windows.Forms;

namespace Game
{
    public partial class MyForm
    {
        private readonly Timer moveTimer = new() {Interval = 100};
        private readonly Timer addVisitorTimer = new() {Interval = 2000};
        private void UpdateAddVisitorTimer(object sender, EventArgs e)
        {
            if (game.Visitors.Count >= global::Model.Game.MaxCountVisitors || game.Random.Next(0, 2) == 0) return;
            var visitor = new Visitor(game, new Point(419, 684), 6, new Size(28, 20));
            game.Add(visitor);
            visitor.GoToBar();
            Invalidate();
        }
        
        private void UpdateMoveTimer(object sender, EventArgs e)
        {
            if (game.Player.IsMoving)
                game.Player.Move(game.Player.Direction);

            foreach (var visitor in game.Visitors)
            {
                if (visitor.Out)
                {
                    game.Objects.Remove(game.Visitors.Dequeue());
                    break;
                }

                if (visitor.Track.Count != 0)
                    visitor.Move(visitor.Track.First());
                else
                    visitor.StopMove();
            }
            Invalidate();
        }
    }
}