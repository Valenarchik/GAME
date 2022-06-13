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
            
            InitializationMusic();
            InitializationAnimation();
            InitializeDesign();
            InitializationTimers();
            
            countCoin.Text = game.Money.ToString();
            
            game.MoneyChange += () => countCoin.Text = game.Money.ToString();
            game.Player.CompleteOrder += () => Music.Sell.controls.play();
            game.TrashBox.ThrowOutTrash += () => Music.TrashBox.controls.play();

            exitButton.Click += (_, _) => Close();
            bookButton.Click += OnBookButtonClick;
            rentOkButton.Click += OnRentOkButtonClick;
            closeRifledBoardButton.Click += OnCloseRifledBoardButtonClick;
            learButton.Click+= LearButtonOnClick;
            closeGuideButton.Click+= CloseGuideButtonOnClick; 
            nextPageGuideButton.Click += NextPageGuideButtonOnClick;   
            previousPageGuideButton.Click += PreviousPageGuideButtonOnClick;
            continueButton.Click += ContinueButtonOnClick;
            newGameButton.Click += NewGameButtonOnClick;
            settingsButton.Click += SettingsButtonOnClick;
            musicBar.Scroll+= MusicBarOnScroll;
            soundEffectBar.Scroll += SoundEffectBarOnScroll;
            backToMenu.Click += BackToMenuOnClick;
        }

        private void BackToMenuOnClick(object sender, EventArgs e)
        {
            musicBar.Hide();
            musicBarText.Hide();
            soundEffectBar.Hide();
            soundEffectBarText.Hide();
            backToMenu.Hide();

            if (game.IsOver)
                newGameButton.Show();
            else
                continueButton.Show();
            
            learButton.Show();
            settingsButton.Show();
            exitButton.Show();
        }

        private void SoundEffectBarOnScroll(object sender, EventArgs e)
        {
            Music.SoundEffectVolume = ((TrackBar)sender).Value;
            soundEffectBarText.Text = $@"Громкость звуков:{Music.SoundEffectVolume}";
        }

        private void MusicBarOnScroll(object sender, EventArgs e)
        {
            Music.MusicVolume = ((TrackBar)sender).Value;
            musicBarText.Text = $@"Громкость музыки:{Music.MusicVolume}";
        }

        private void SettingsButtonOnClick(object sender, EventArgs e)
        {
            continueButton.Hide();
            newGameButton.Hide();
            learButton.Hide();
            settingsButton.Hide();
            exitButton.Hide();
            
            musicBar.Show();
            musicBarText.Show();
            soundEffectBar.Show();
            soundEffectBarText.Show();
            backToMenu.Show();
        }

        private void NewGameButtonOnClick(object sender, EventArgs e)
        {
            continueButton.Show();
            newGameButton.Hide();
            menuBackground.Hide();
            if(game.IsOver)
            {
                Music.RestaurantMusic.controls.play();
                gameOver.Hide();
                pizzaMaster.Show();
                game.Restart();
            }
            
            StartGame();
        }

        private void ContinueButtonOnClick(object sender, EventArgs args)
        {
            menuBackground.Hide();
            StartGame();
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
            if(game.IsOver)
                gameOver.Show();
            else 
                pizzaMaster.Show();
            guide.Hide();
            Music.CloseBook.controls.play();
        }

        private void LearButtonOnClick(object sender, EventArgs e)
        {
            menu.Hide();
            pizzaMaster.Hide();
            gameOver.Hide();
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
            StartGame();
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