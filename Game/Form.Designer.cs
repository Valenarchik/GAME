using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Game.Model;
namespace Game
{
    sealed partial class MyForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            Name = "Pizza Master";
            Text = "Pizza Master";
            BackgroundImage = Sprites.Background.BackgroundImage;
            game = new GameLevel(1040,704);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = game.GameSize;
            InitializateInterior();
            
        }

        private void InitializateInterior()
        {
            game.Objects[Type.Interior] = new List<GameObject>
            {
                //квадратные столы
                new Interior(game,new Point(94,168),new Size(96,32)),
                new Interior(game,new Point(94,388),new Size(96,32)),
                new Interior(game,new Point(94,285),new Size(96,32)),
                //скамейки
                new Interior(game,new Point(103,153),new Size(79,13)),
                new Interior(game,new Point(103,209),new Size(79,13)),
                new Interior(game,new Point(103,270),new Size(79,13)),
                new Interior(game,new Point(103,329),new Size(79,13)),
                new Interior(game,new Point(103,374),new Size(79,13)),
                new Interior(game,new Point(103,431),new Size(79,13)),
                //круглые столы
                new Interior(game,new Point(115    ,528),new Size(63,43)),
                new Interior(game,new Point(272    ,528),new Size(63,43)),
                new Interior(game,new Point(494    ,528),new Size(63,43)),
                //табуретки
                new Interior(game,new Point(134    ,505),new Size(25,15)),
                new Interior(game,new Point(87     ,543),new Size(25,15)),
                new Interior(game,new Point(134    ,580),new Size(25,15)),
                new Interior(game,new Point(181    ,543),new Size(25,15)),
                //
                new Interior(game,new Point(134+157,505),new Size(25,15)),
                new Interior(game,new Point(87 +157,543),new Size(25,15)),
                new Interior(game,new Point(134+157,580),new Size(25,15)),
                new Interior(game,new Point(181+157,543),new Size(25,15)),
                //
                new Interior(game,new Point(134+379,505),new Size(25,15)),
                new Interior(game,new Point(87 +379,543),new Size(25,15)),
                new Interior(game,new Point(134+379,580),new Size(25,15)),
                new Interior(game,new Point(181+379,543),new Size(25,15)),
                //стенки бара
                new Interior(game,new Point(369,215),new Size(24,160)),
                new Interior(game,new Point(369,344),new Size(243,30)),
                new Interior(game,new Point(369,108),new Size(24,75)),
                new Interior(game,new Point(394,105),new Size(217,33)),
                //табуретки у бара
                new Interior(game,new Point(328,146),new Size(31,22)),
                new Interior(game,new Point(328,233),new Size(31,22)),
                new Interior(game,new Point(328,277),new Size(31,22)),
                new Interior(game,new Point(328,329),new Size(31,22)),
                new Interior(game,new Point(388,382),new Size(31,22)),
                new Interior(game,new Point(568,382),new Size(31,22)),
                //часы
                new Interior(game,new Point(62,148),new Size(19,17)),
                //стены
                new Interior(game,new Point(0,0),new Size(36,653)),
                new Interior(game,new Point(0,652),new Size(1040,52)),
                new Interior(game,new Point(0,0),new Size(1040,127)),
                new Interior(game,new Point(995,0),new Size(45,704)),
                new Interior(game,new Point(611,315),new Size(64,351)),
                new Interior(game,new Point(611,120),new Size(65,118)),
                //печки
                new Interior(game,new Point(738,107),new Size(64,34)),
                new Interior(game,new Point(847,107),new Size(64,34)),
                //бочки
                new Interior(game,new Point(39,608),new Size(60,44)),
            };
        }
    }
}

