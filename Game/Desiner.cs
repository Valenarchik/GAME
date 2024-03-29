﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Game.SpritesAndMusic;

namespace Game
{
    public partial class MyForm
    {
        private static readonly Color backColor = Color.FromArgb(141, 111, 27);
        private static readonly Color foreColor = Color.FromArgb(233,177,20);
        private void InitializeDesign()
        {
            menuBackground.Controls.Add(menu);
            menuBackground.Controls.Add(pizzaMaster);
            menuBackground.Controls.Add(gameOver);
            gameOver.Hide();
            
            menu.Controls.Add(newGameButton);
            menu.Controls.Add(continueButton);
            continueButton.Hide();
            menu.Controls.Add(learButton);
            menu.Controls.Add(settingsButton);
            menu.Controls.Add(exitButton);
            menu.Controls.Add(musicBar);
            menu.Controls.Add(musicBarText);
            musicBarText.Hide();
            musicBar.Hide();
            menu.Controls.Add(soundEffectBar);
            menu.Controls.Add(soundEffectBarText);
            soundEffectBar.Hide();
            soundEffectBarText.Hide();
            menu.Controls.Add(backToMenu);
            backToMenu.Hide();
       

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
            
            InitializationRifledBoard();
        }
        //Меню
        private readonly PictureBox menuBackground = new ()
        {
            Location = new Point(0, 0),
            BackgroundImage = Interface.MenuBackground,
            Size = Interface.MenuBackground.Size,
        };

        private readonly PictureBox menu = new()
        {
            BackgroundImage = Interface.MenuTab,
            Size = Interface.MenuTab.Size,
            Location = new Point(365,171),
            BackColor = Color.Transparent
        };
        
        private readonly PictureBox pizzaMaster = new()
        {
            BackgroundImage = Interface.PizzaMaster,
            Size = Interface.PizzaMaster.Size,
            Location = new Point(208,0),
            BackColor = Color.Transparent
        };
        
        private readonly PictureBox gameOver = new()
        {
            Location = new Point(206,3),
            BackgroundImage = Interface.GameOver,
            Size = Interface.GameOver.Size,
            BackColor = Color.Transparent,
        };

        private readonly Button continueButton = new()
        {
            Text = "Продолжить",
            Location = new Point(50,59),
            BackColor = backColor,
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 22),
            FlatStyle = FlatStyle.Flat,
        };
        private readonly Button newGameButton = new()
        {
            Text = "Новая игра",
            Location = new Point(50,59),
            BackColor = backColor,
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 22),
            FlatStyle = FlatStyle.Flat,
        };
        
        private readonly Button learButton = new()
        {
            Text = "Обучение",
            Location = new Point(50,151),
            BackColor = backColor,
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        
        private readonly Button settingsButton = new()
        {
            Text = "Настройки",
            Location = new Point(50,243),
            BackColor = backColor,
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        
        private readonly Button exitButton = new()
        {
            Text = "Выход",
            Location = new Point(50,334),
            BackColor = backColor,
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        //Настройки
        private readonly Label musicBarText = new()
        {
            Location = new Point(50,59),
            Text = $@"Громкость музыки:{Music.MusicVolume}",
            Size = new Size(214,20),
            BackColor = backColor,
            Font = new Font(FontFamily.GenericMonospace, 12),
        };
        private readonly TrackBar musicBar = new()
        {
            Location = new Point(50,79),
            BackColor = backColor,
            Size = new Size(214,47),
            Maximum = 100,
            Value = Music.MusicVolume,
            TickFrequency = 5,
        };
        
        private readonly Label soundEffectBarText = new()
        {
            Location = new Point(50,151),
            Text = $@"Громкость звуков:{Music.SoundEffectVolume}",
            Size = new Size(214,20),
            BackColor = backColor,
            Font = new Font(FontFamily.GenericMonospace, 12),
        };
        private readonly TrackBar soundEffectBar = new()
        {
            Location = new Point(50,171),
            BackColor = backColor,
            Size = new Size(214,47),
            Maximum = 100,
            Value = Music.SoundEffectVolume,
            TickFrequency = 5,
        };

        private readonly Button backToMenu = new()
        {
            Text = "Назад",
            Location = new Point(50,334),
            BackColor = backColor,
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };

        //Обучение 
        private readonly PictureBox guide = new()
        {
            Location = new Point(162,103),
            BackgroundImage = Interface.Guide1,
            BackColor = Color.Transparent,
            Size = Interface.Guide1.Size,
        };
        
        private readonly PictureBox closeGuideButton = new()
        {
            Location = new Point(667,25),
            BackgroundImage = Interface.CloseGuide,
            BackColor = Color.Transparent,
            Size = Interface.CloseGuide.Size,
        };
        
        private readonly PictureBox nextPageGuideButton = new()
        {
            Location = new Point(660,439),
            BackgroundImage = Interface.ForwardArrow,
            BackColor = Color.Transparent,
            Size = Interface.ForwardArrow.Size,
        };
        
        private readonly PictureBox previousPageGuideButton = new()
        {
            Location = new Point(32,439),
            BackgroundImage = Interface.ArrowBack,
            BackColor = Color.Transparent,
            Size = Interface.ArrowBack.Size,
        };
        //

        private readonly PictureBox recipes = new()
        {
            BackgroundImage = Interface.Recipes,
            Location = new Point(162,103),
            Size = Interface.Recipes.Size,
            BackColor = Color.Transparent
        };

        private readonly PictureBox bookButton = new()
        {
            BackgroundImage = Interface.Book,
            Location = new Point(990,11),
            Size = Interface.Book.Size,
            BackColor = Color.Transparent,
        };
        
        private readonly PictureBox rifledBoard = new ()
        {
            Location = new Point(159, 194),
            BackgroundImage = Interface.RifledBoard,
            Size =  Interface.RifledBoard.Size,
        };
        
        private readonly FlowLayoutPanel ingredients = new ()
        {
            Location = new Point(65, 306),
            Size = new Size(571, 55),
            BackColor = Color.Transparent,
        };

        private readonly List<PictureBox> ingredientButtons = new ()
        {
            new() {Image = Meal.Dough,Name = "Dough"},
            new() {Image = Meal.Tomato,Name = "Tomato"},
            new() {Image = Meal.Basil,Name = "Basil"},
            new() {Image = Meal.Cheese,Name = "Cheese"},
            new() {Image = Meal.TomatoSauce,Name = "TomatoSauce"},
            new() {Image = Meal.Pepperoni,Name = "Pepperoni"},
            new() {Image = Meal.Mushroom,Name = "Mushroom"},
            new() {Image = Meal.Chicken,Name = "ChickenFillet"},
        };

        private readonly PictureBox closeRifledBoardButton = new ()
        {
            BackgroundImage = Interface.CloseButton,
            Size = Interface.CloseButton.Size,
            BackColor = Color.Transparent,
            BorderStyle = BorderStyle.None,
            Location = new Point(673,4)
        };

        private readonly PictureBox buttonE = new ()
        {
            Image = Interface.ButtonE,
            Size = Interface.ButtonE.Size,
            BackColor = Color.Transparent,
        };
        
        private readonly List<PictureBox> ingredientsOnTable = new ()
        {
            new PictureBox{Location =  new Point(54, 96),BackColor = Color.Transparent,Size = new Size(104,104)},
            new PictureBox{Location =  new Point(157, 18),BackColor = Color.Transparent,Size = new Size(104,104)},
            new PictureBox{Location =  new Point(157, 174),BackColor = Color.Transparent,Size = new Size(104,104)},
            new PictureBox{Location =  new Point(260, 96),BackColor = Color.Transparent,Size = new Size(104,104)},
        };

        private readonly PictureBox cookPizzaPictureBox = new ()
        {
            BackColor = Color.Black,
            Location = new Point(192,130),
            Size = new Size(36,36),
            Image = Interface.Ok,
            SizeMode = PictureBoxSizeMode.CenterImage,
        };

        private readonly PictureBox pizzaPictureBox = new()
        {
            Location =  new Point(448, 66),
            BackColor = Color.Transparent,
            Size = new Size(161,161)
        };

        private readonly Label countCoin = new()
        {
            Font = new Font(FontFamily.GenericMonospace, 20),
            ForeColor = Color.Yellow,
            BackColor = Color.Transparent,
            Location = new Point(61,12),
            Size = new Size(188,33)
        };

        private readonly Panel rentMenu = new()
        {
            BackgroundImage = Interface.RentMenu,
            Size = Interface.RentMenu.Size,
            Location = new Point(417,228),
        };
        
        
        // Аренда
        private readonly Label rentText = new ()
        {
            Text = "Аренда:",
            BackColor = Color.Transparent,
            ForeColor = foreColor,
            Font = new Font(FontFamily.GenericMonospace, 24),
            Location = new Point(15,15),
            Size = new Size(176,55),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        
        private readonly Label rentMoneyText = new ()
        {
            BackColor = Color.Transparent,
            ForeColor = foreColor,
            Font = new Font(FontFamily.GenericMonospace, 24),
            Location = new Point(46,95),
            Size = new Size(114,50),
            TextAlign = ContentAlignment.MiddleCenter,
        };
        
        private readonly Button rentOkButton = new ()
        {
            Text = "Ок",
            ForeColor = foreColor,
            Font = new Font(FontFamily.GenericMonospace, 16),
            Location = new Point(43,200),
            Size = new Size(120,31),
            FlatStyle = FlatStyle.Flat,
            BackColor = backColor,
        };
        //
    }
}