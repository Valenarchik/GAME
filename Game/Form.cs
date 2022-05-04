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
            PaintMatrix(e.Graphics);
            PlayerAnimation(e.Graphics);
            PaintTabBar(e.Graphics);
        }

        private void PaintTabBar(Graphics g)
        {
            g.DrawImage(Sprites.Other.TabBar,new Point(297,633));
        }
        private void PaintMatrix(Graphics g)
        {
            var brushes = Brushes.Chartreuse;
            if(game.Player.GetNeighbourInRadius(20,TypeInterior.Bench)!=null)
                brushes = Brushes.Cyan;
            foreach (var e in game.Objects)
            {
                g.FillRectangle(brushes,new Rectangle(e.Position,e.Size));
            }
        }
    }
}
