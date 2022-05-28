using System;
using System.Drawing;
using System.Windows.Forms;
using Accessibility;
using Game.SpritesAndMusic;

namespace Game
{
    sealed partial class MyForm
    {
        private void InitializeComponent()
        {
            Name = $"Пицца Мастер";
            Text = @"Пицца Мастер";
            DoubleBuffered = true;
            KeyPreview = true;
            MaximizeBox = false;
            BackgroundImage = Interface.BackgroundImage;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = menu.Size = new Size(game.Width, game.Height);
            startButton.Click += OnStartButtonClick;
            closeRifledBoardButton.Click += OnCloseRifledBoardButtonClick;
            menu.Controls.Add(startButton);
            menu.Controls.Add(learButton);
            menu.Controls.Add(settingsButton);
            menu.Controls.Add(exitButton);
            
            Controls.Add(menu);
            Controls.Add(buttonE);
            Controls.Add(countCoin);
            Controls.Add(bookButton);
            Controls.Add(recipes);
            recipes.Hide();
            
            Controls.Add(rentMenu);
            rentMenu.Controls.Add(rentText);
            rentMenu.Controls.Add(rentMoneyText);
            rentMenu.Controls.Add(rentOkButton);
            rentMenu.Hide();


            //
            //Music.MadnessPlayer.controls.stop();
            Music.FireSoundPlayer.controls.stop();
            Music.WalkingOnWood.controls.stop();
            Music.WalkingOnConcrete.controls.stop();
            Music.TrashBox.controls.stop();
            Music.Sell.controls.stop();
            Music.TurnPage.controls.stop();
            Music.CloseBook.controls.stop();
            Music.Madness.controls.stop();
            Music.IronDoor.controls.stop();
            Music.WastingCoins.controls.stop();
            //Music.FingersnapBar.controls.stop();
            
            Music.Madness.PlayStateChange += OnMadnessPlayStateChange;
            Music.FingersnapBar.PlayStateChange += OnFingersnapBarStateChange;

            //
            InitializationRifledBoard();
            InitializationAnimation();
            game.Start();
            game.MoneyChange += () => countCoin.Text = game.Money.ToString();
            countCoin.Text = game.Money.ToString();
            game.Player.CompleteOrder += () => Music.Sell.controls.play();
            game.TrashBox.ThrowOutTrash += () => Music.TrashBox.controls.play();
            moveTimer.Tick += UpdateMoveTimer;
            addVisitorTimer.Tick += UpdateAddVisitorTimer;
            exitButton.Click += (_, _) => Close();
            bookButton.Click += OnBookButtonClick;
            rentOkButton.Click += OnRentOkButtonClick;
        }

        private void OnRentOkButtonClick(object sender, EventArgs e)
        {
            rentMenu.Hide();
            if(!rifledBoard.Visible)
            {
                Controls.Add(buttonE);
                game.Player.CanGo = true;
            }
            DayTimer.Start();
        }
        
        private void OnFingersnapBarStateChange(int newState)
        {
            if (newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
                Music.Madness.controls.play();
        }
        
        private void OnMadnessPlayStateChange(int newState)
        {
            if (newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
                Music.FingersnapBar.controls.play();
        }
        private void OnBookButtonClick(object sender, EventArgs e)
        {
            if(recipes.Visible)
            {
                Music.CloseBook.controls.play();
                if(!rifledBoard.Visible)Controls.Add(buttonE);
                recipes.Hide();
            }
            else
            {
                Music.TurnPage.controls.play();
                Controls.Remove(buttonE);
                recipes.Show();
            }
        }
    }
}