using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Game.Sprites;

namespace Game
{
    public partial class MyForm
    {
        private readonly Panel menu = new Panel()
        {
            Location = new Point(0, 0),
            BackColor = Color.Black
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

        private readonly List<PictureBox> ingredientsList = new List<PictureBox>()
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
        private readonly Button startButton = new Button()
        {
            Text = "Старт",
            ForeColor = Color.White,
            AutoSize = true,
            Font = new Font(FontFamily.GenericMonospace, 20),
        };
        private readonly PictureBox buttonE = new PictureBox()
        {
            Image = Interface.ButtonE,
            Size = Interface.ButtonE.Size,
            BackColor = Color.Transparent,
        };
        
        private readonly List<PictureBox> ingredientsPictureBoxes = new ()
        {
            new PictureBox{Location =  new Point(54, 96),BackColor = Color.Transparent,Size = new Size(104,104)},
            new PictureBox{Location =  new Point(157, 18),BackColor = Color.Transparent,Size = new Size(104,104)},
            new PictureBox{Location =  new Point(157, 174),BackColor = Color.Transparent,Size = new Size(104,104)},
            new PictureBox{Location =  new Point(260, 96),BackColor = Color.Transparent,Size = new Size(104,104)},
        };

        private readonly PictureBox pizzaPictureBox = new()
        {
            Location =  new Point(448, 66),
            BackColor = Color.Transparent,
            Size = new Size(161,161)
        };

    }
}