using System;
using System.Drawing;
using System.Windows.Forms;
using Accessibility;
using Game.Model;

namespace Game
{
    sealed partial class MyForm
    {
        private void InitializeComponent()
        {
            Name = "Pizza Master";
            Text = "Pizza Master";
            DoubleBuffered = true;
            BackgroundImage = Sprites.Interface.BackgroundImage;
            game = new Model.Game(1040, 704);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = menu.Size = new Size(game.Width, game.Height);
            KeyPreview = true;
            startButton.Click += OnStartButtonClick;
            closeRifledBoardButton.Click += OnCloseRifledBoardButtonClick;
            menu.Controls.Add(startButton);
            Controls.Add(menu);
            Controls.Add(buttonE);
            Controls.Add(CountCoin);
            game.MoneyChange += () => CountCoin.Text = game.Money.ToString();
            game.Money = 20;
            InitializationRifledBoard();
            InitializationAnimation();
            InitializationGameObjects();
        }
        
        private void OnCloseRifledBoardButtonClick(object sender, EventArgs args)
        {
            rifledBoard.Hide();
            game.Player.CanGo = true;
            Controls.Add(buttonE);
        }

        private void OnStartButtonClick(object sender, EventArgs args)
        {
            menu.Hide();
            moveTimer.Start();
            addVisitorTimer.Start();
        }
    }
}