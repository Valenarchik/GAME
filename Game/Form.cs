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
        private Sprites.Chef chefSprites = new Sprites.Chef();
        private Sprites.VisitorOne visitorOneSprites = new Sprites.VisitorOne();
        private Sprites.VisitorTwo visitorTwoSprites = new Sprites.VisitorTwo();
        
        private Timer timer = new Timer() {Interval = 200};
        
        public MyForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            timer.Tick += OnTick;
            Paint += OnPaint;
            KeyDown += OnPressDown;
            KeyUp += OnPressUp;
            timer.Start();
        }

        private void OnTick(object sender, EventArgs args)
        {
            if (game.Player.IsMoving)
                game.Player.Move(game.Player.Direction);
            unchecked {time++;}

            foreach (var visitor in game.Visitors)
            {
                if(visitor.Way.Count != 0)
                    visitor.Move(visitor.Way.First());
                else
                    visitor.StopMove();
            }
            Invalidate();
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
            foreach (var visitor in game.Visitors.Where(x=>x.Position.Y <= game.Player.Position.Y))
                EntityAnimation(e.Graphics,visitor,visitorOneSprites);
            EntityAnimation(e.Graphics,game.Player, chefSprites);
            foreach (var visitor in game.Visitors.Where(x=>x.Position.Y > game.Player.Position.Y))
                EntityAnimation(e.Graphics,visitor,visitorOneSprites);
            PaintTabBar(e.Graphics);
        }

        private void PaintTabBar(Graphics g)
        {
            g.DrawImage(Sprites.Other.TabBar,new Point(481,636));
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
            foreach (var o in game.Objects)
                g.FillRectangle(Brushes.Chartreuse, new Rectangle(o.Position,o.Size));
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
        private void OnStartButtonClick(object sender, EventArgs e)
        {
            menu.Hide();
        }
    }
}
