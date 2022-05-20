using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;
using Game.Sprites;

namespace Game
{
    public sealed partial class MyForm
    {
        private Model.Game game;
        private readonly ChefSprites chefSprites = new();
        private readonly VisitorOneSprites visitorOneSprites = new();
        private readonly VisitorTwoSprites visitorTwoSprites = new();
        private readonly Timer moveTimer = new() {Interval = 100};
        private readonly Timer addVisitorTimer = new() {Interval = 1000};

        public MyForm()
        {
            
            InitializeComponent();
            DoubleBuffered = true;
            Paint += OnPaint;
            KeyDown += OnPressDown;
            KeyUp += OnPressUp;

            moveTimer.Tick += (_, _) =>
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
            };

            addVisitorTimer.Tick += (_, _) =>
            {
                if (game.Visitors.Count >= Model.Game.MaxCountVisitors || game.Random.Next(0, 2) == 0) return;
                var visitor = new Visitor(game, new Point(419, 684), 6, new Size(28, 20));
                game.Add(visitor);
                visitor.GoToBar();
                Invalidate();
            };
            
        }

        private void OnPressDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.Player.Move(Direction.Up);
                    break;
                case Keys.A:
                    game.Player.Move(Direction.Left);
                    break;
                case Keys.S:
                    game.Player.Move(Direction.Down);
                    break;
                case Keys.D:
                    game.Player.Move(Direction.Right);
                    break;
                case Keys.E:
                    game.Player.CompleteOrder();
                    game.Player.AcceptOrder();
                    break;
            }
            Invalidate();
        }

        private void OnPressUp(object sender, KeyEventArgs e)
        {
            game.Player.StopMove();
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            //PaintMatrix(e.Graphics);
            PaintFurnace(e.Graphics);
            PaintClock(e.Graphics);
            PaintVisitor(e.Graphics, game.Visitors.Where(x => x.Position.Y <= game.Player.Position.Y));
            PaintPlayer(e.Graphics);
            PaintVisitor(e.Graphics, game.Visitors.Where(x => x.Position.Y > game.Player.Position.Y));
            PaintInterior(e.Graphics);
            PaintTabBar(e.Graphics);
        }

        private void PaintClock(Graphics g)
        {
            g.DrawImage(Sprites.Interior.Clock, new Point(62,94));
        }

        private void PaintFurnace(Graphics g)
        {
            g.DrawImage(Sprites.Interior.FurnaceTypeOne, new Point(789,60));
            g.DrawImage(Sprites.Interior.FurnaceTypeOne, new Point(708,60));
        }
        
        private void PaintTabBar(Graphics g)
        {
            g.DrawImage(Interface.TabBar,new Point(481,636));
        }

        private void PaintPlayer(Graphics g)
        {
            EntityAnimation(g, game.Player, chefSprites);
            var visitor = game.Visitors.FirstOrDefault(x => !x.OrderAccepted || x.OrderAccepted && !x.OrderIsCompleted);
            if (visitor is not null
                && visitor.OrderIsActivated
                && !visitor.OrderIsCompleted
                && Model.Game.InZone(game.Player, visitor, Player.ActivationRadius))
            {
                buttonE.Show();
                buttonE.Location = game.Player.Position + new Size(30, -48);
            }
            else
                buttonE.Hide();
        }

        private void PaintVisitor(Graphics g, IEnumerable<Visitor> visitors)
        {
            foreach (var visitor in visitors)
            {
                if(visitor.TypeVisitor == TypeVisitor.Green) 
                    EntityAnimation(g, visitor, visitorOneSprites);
                else
                    EntityAnimation(g, visitor, visitorTwoSprites);
            }
        }
        
        private void PaintInterior(Graphics g)
        {
            if(game.Player.Position.Y <=328)
                g.DrawImage(Sprites.Interior.Wall,new Point(611,278));
            if(game.Player.Position.Y <=650)
                g.DrawImage(Sprites.Interior.Barrels,new Point(40,608));
            if(game.Player.Position.Y <=161)
                g.DrawImage(Sprites.Interior.Wardrobe,new Point(577,127));
            if(game.Player.Position.Y <=344)
                g.DrawImage(Sprites.Interior.Cup,new Point(424,336));
        }
        
        private void PaintMatrix(Graphics g)
        {
            foreach (var o in game.Objects)
                g.FillRectangle(Brushes.Chartreuse, new Rectangle(o.Position,o.Size));
        }
    }
}
