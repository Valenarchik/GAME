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
            ClientSize = menuBackground.Size = new Size(game.Width, game.Height);
            startButton.Click += OnStartButtonClick;
            closeRifledBoardButton.Click += OnCloseRifledBoardButtonClick;
            
            menuBackground.Controls.Add(menu);
            menuBackground.Controls.Add(pizzaMaster);
            
            menu.Controls.Add(startButton);
            menu.Controls.Add(learButton);
            menu.Controls.Add(settingsButton);
            menu.Controls.Add(exitButton);

            Controls.Add(menuBackground);
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

            menuBackground.Controls.Add(guide);
            guide.Controls.Add(closeGuideButton);
            guide.Controls.Add(nextPageGuideButton);
            guide.Controls.Add(previousPageGuideButton);
            guide.Hide();
            previousPageGuideButton.Hide();

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
            
            learButton.Click+= LearButtonOnClick;
            closeGuideButton.Click+= CloseGuideButtonOnClick; 
            nextPageGuideButton.Click += NextPageGuideButtonOnClick;   
            previousPageGuideButton.Click += PreviousPageGuideButtonOnClick;
        }

        private void PreviousPageGuideButtonOnClick(object sender, EventArgs e)
        {
            nextPageGuideButton.Show();
            previousPageGuideButton.Hide();
            guide.Image = Interface.Guide1;
            Music.TurnPage.controls.play();
        }

        private void NextPageGuideButtonOnClick(object sender, EventArgs e)
        {
            nextPageGuideButton.Hide();
            previousPageGuideButton.Show();
            guide.Image = Interface.Guide2;
            Music.TurnPage.controls.play();
        }

        private void CloseGuideButtonOnClick(object sender, EventArgs e)
        {
            menu.Show();
            pizzaMaster.Show();
            guide.Hide();
            Music.CloseBook.controls.play();
        }

        private void LearButtonOnClick(object sender, EventArgs e)
        {
            menu.Hide();
            pizzaMaster.Hide();
            guide.Show();
            Music.TurnPage.controls.play();
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
            addVisitorTimer.Start();
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