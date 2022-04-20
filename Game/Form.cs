using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public sealed partial class MyForm : Form
    {
        private Player player;
        private DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
        private int time;
        public MyForm()
        {
            DoubleBuffered = true;
            var timer = new Timer();
            timer.Interval += 100;
            timer.Tick += (sender, args) =>
            {
                if (player.IsMoving)
                    player.Move(player.Direction);
                unchecked {time++;}
                Invalidate();
            };
            timer.Start();
            Paint += OnPaint;
            KeyDown += OnPressDown;
            KeyUp += OnPressUp;
            InitializeComponent();
            Initialize();
        }

        private void OnPressDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.Move(Directions.Up);
                    break;
                case Keys.A:
                    player.Move(Directions.Left);
                    break;
                case Keys.S:
                    player.Move(Directions.Down);
                    break;
                case Keys.D:
                    player.Move(Directions.Right);
                    break;
            }
            Invalidate();
        }

        private void OnPressUp(object sender, KeyEventArgs e)
        {
            player.StopMove();
        }

        private void Initialize()
        {
            player = new Player(new Point(100, 100),5, new Size(48, 64));
            Invalidate();
        }
         
        private void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (player.IsMoving)
                switch (player.Direction)
                {
                    case Directions.Up:
                        DrawAnimation(g, player, Sprites.ChefMoveUp1, Sprites.ChefMoveUp2);
                        break;
                    case Directions.Right:
                        DrawAnimation(g, player, Sprites.ChefMoveRight1, Sprites.ChefMoveRight2);
                        break;
                    case Directions.Down:
                        DrawAnimation(g, player, Sprites.ChefMoveDown1, Sprites.ChefMoveDown2);
                        break;
                    case Directions.Left:
                        DrawAnimation(g, player, Sprites.ChefMoveLeft1, Sprites.ChefMoveLeft2);
                        break;
                }
            else
            {
                switch (player.Direction)
                {
                    case Directions.Up:
                        DrawAnimation(g, player, Sprites.ChefStandUp);
                        break;
                    case Directions.Right:
                        DrawAnimation(g, player, Sprites.ChefStandRight);
                        break;
                    case Directions.Down:
                        DrawAnimation(g, player, Sprites.ChefStandDown);
                        break;
                    case Directions.Left:
                        DrawAnimation(g, player, Sprites.ChefStandLeft);
                        break;
                } 
            }
        }

        private void DrawAnimation (Graphics g, Entity entity,params Image[] sprites)
        {
            if (sprites is null) return;
            g.DrawImage(sprites[time % sprites.Length], entity.Position);
        }
    }
}
