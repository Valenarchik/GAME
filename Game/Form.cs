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
        private Image ChefSprite;
        private int time;
        public MyForm()
        {
            DoubleBuffered = true;
            var timer = new Timer();
            timer.Interval += 200;
            timer.Tick += (sender, args) =>
            {
                time++;
                Invalidate();
            };
            timer.Start();
            Paint += OnPaint;
            KeyDown += OnPressDown;
            KeyUp += OnPressUp;
            InitializeComponent();
            Initialize();
        }

        private void OnPressDown(object? sender, KeyEventArgs e)
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

        private void OnPressUp(object? sender, KeyEventArgs e)
        {
            player.StopMove();
        }
        public void Initialize()
        {
            ChefSprite = new Bitmap(@"C:\Users\днс\source\repos\Game\Game\Sprites\Chef.png");
            player = new Player(new Point(100, 100), new Size(12, 19));
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Animation(graphics,ChefSprite,player,3);
        }

        private void Animation (Graphics g, Image sprite, Entity entity, int countFrames)
        {
            g.DrawImage(sprite, entity.Position,
                new RectangleF(new PointF(entity.Size.Width * (time % countFrames), 0), entity.Size),
                GraphicsUnit.Pixel);
        }
    }
}
