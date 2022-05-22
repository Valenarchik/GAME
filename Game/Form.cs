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
                    OpenRifledBoard();
                    break;
            }
            Invalidate();
        }

        private void OnPressUp(object sender, KeyEventArgs e)
        {
            game.Player.StopMove();
        }
        
        private void OpenRifledBoard()
        {
            if (!Model.Game.InZone(game.Player, game.RifledBoard, 10))
                return;
            RifledBoard.Show();
            Controls.Remove(buttonE);
            game.Player.CanGo = false;
        }
    }
}
