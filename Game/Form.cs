using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public sealed partial class MyForm : Form
    {
        private Model.Game game;
        private int time;
        public MyForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            var timer = new Timer();
            timer.Interval += 50;
            timer.Tick += (sender, args) =>
            {
                if (game.Player.IsMoving)
                    game.Player.Move(game.Player.Direction);
                unchecked {time++;}
                Invalidate();
            };
            timer.Start();
            Paint += OnPaint;
            KeyDown += OnPressDown;
            KeyUp += OnPressUp;
        }

        private void OnPressDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.Player.Move(Directions.Up);
                    break;
                case Keys.A:
                    game.Player.Move(Directions.Left);
                    break;
                case Keys.S:
                    game.Player.Move(Directions.Down);
                    break;
                case Keys.D:
                    game.Player.Move(Directions.Right);
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
            PaintClock(e.Graphics);
            //PaintMatrix(e.Graphics);
            PlayerAnimation(e.Graphics);
            if(game.Player.Position.Y <=328)
                e.Graphics.DrawImage(Sprites.Interior.Wall,new Point(611,278));
            if(game.Player.Position.Y <=650)
                e.Graphics.DrawImage(Sprites.Interior.Barrels,new Point(40,608));
            if(game.Player.Position.Y <=161)
                e.Graphics.DrawImage(Sprites.Interior.Wardrobe,new Point(577,127));
            if(game.Player.Position.Y <=344)
                e.Graphics.DrawImage(Sprites.Interior.Cup,new Point(424,336));

            PaintTabBar(e.Graphics);
        }

        private void PaintTabBar(Graphics g)
        {
            g.DrawImage(Sprites.Other.TabBar,new Point(297,633));
        }

        private void PaintClock(Graphics g)
        {
            switch (time/3%4)
            {
                case 0:
                    g.DrawImage(Sprites.Interior.Clock1,new Point(62,92));
                    break;
                case 1:
                    g.DrawImage(Sprites.Interior.Clock2,new Point(62,92));
                    break;
                case 2:
                    g.DrawImage(Sprites.Interior.Clock3,new Point(62,92));
                    break;
                case 3:
                    g.DrawImage(Sprites.Interior.Clock2,new Point(62,92));
                    break;
            }
        }
        private void PaintMatrix(Graphics g)
        {
            foreach (var e in game.Objects)
            {
                g.FillRectangle(Brushes.Lime, new Rectangle(e.Position,e.Size));
            }
        }

        private void OnStartButtonClick(object sender, EventArgs e)
        {
            menu.Hide();
        }
    }
}
