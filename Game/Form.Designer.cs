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
            game = new GameLevel(1000,500);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = game.GameSize;
            InitializateInterior();
            
        }

        private void InitializateInterior()
        {
            game.Objects[Type.Furnace] = new List<GameObject>
            {
                new Furnace(game,new Point(200,100),new Size(32,2)), 
                new Furnace(game,new Point(232,100),new Size(32,2)),
                new Furnace(game,new Point(264,100),new Size(32,2))
            };
        }
    }
}

