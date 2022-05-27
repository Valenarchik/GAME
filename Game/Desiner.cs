using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Game.SpritesAndMusic;

namespace Game
{
    public partial class MyForm
    {
        //Меню
        private readonly Panel menu = new ()
        {
            Location = new Point(0, 0),
            BackgroundImage = Interface.Menu,
            Size = Interface.Menu.Size
        };
        
        private readonly Button startButton = new()
        {
            Text = "Старт",
            Location = new Point(413,220),
            BackColor = Color.FromArgb(141,111,27),
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        
        private readonly Button learButton = new()
        {
            Text = "Обучение",
            Location = new Point(413,303),
            BackColor = Color.FromArgb(141,111,27),
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        
        private readonly Button settingsButton = new()
        {
            Text = "Настройки",
            Location = new Point(413,388),
            BackColor = Color.FromArgb(141,111,27),
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        
        private readonly Button exitButton = new()
        {
            Text = "Выход",
            Location = new Point(413,472),
            BackColor = Color.FromArgb(141,111,27),
            Size = new Size(214,67),
            Font = new Font(FontFamily.GenericMonospace, 24),
            FlatStyle = FlatStyle.Flat,
        };
        //


        private readonly Panel recipes = new()
        {
            BackgroundImage = Interface.Recipes,
            Location = new Point(162,103),
            Size = Interface.Recipes.Size,
        };

        private readonly PictureBox bookButton = new()
        {
            BackgroundImage = Interface.Book,
            Location = new Point(990,11),
            Size = Interface.Book.Size,
            BackColor = Color.Transparent,
        };
        
        private readonly Panel rifledBoard = new Panel()
        {
            Location = new Point(159, 194),
            BackgroundImage = Interface.RifledBoard,
            Size =  Interface.RifledBoard.Size,
        };
        
        private readonly FlowLayoutPanel ingredients = new FlowLayoutPanel()
        {
            Location = new Point(65, 306),
            Size = new Size(571, 55),
            BackColor = Color.Transparent,
        };

        private readonly List<PictureBox> ingredientButtons = new List<PictureBox>()
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

        private readonly PictureBox closeRifledBoardButton = new PictureBox()
        {
            BackgroundImage = Interface.CloseButton,
            Size = Interface.CloseButton.Size,
            BackColor = Color.Transparent,
            BorderStyle = BorderStyle.None,
            Location = new Point(673,4)
        };

        private readonly PictureBox buttonE = new PictureBox()
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

        private readonly PictureBox makePizzaPictureBox = new PictureBox()
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
    }
}