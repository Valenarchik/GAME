using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;
using Game.Sprites;
using Interior = Game.Model.Interior;

namespace Game
{
    sealed partial class MyForm
    {
        private Panel menu = new Panel()
        {
            Location = new Point(0, 0),
            BackColor = Color.Black
        };

        private Panel RifledBoard = new Panel()
        {
            Location = new Point(159, 194),
            BackgroundImage = Interface.RifledBoard,
            Size =  Interface.RifledBoard.Size,
        };

        private FlowLayoutPanel Ingredients = new FlowLayoutPanel()
        {
            Location = new Point(65, 306),
            Size = new Size(571, 55),
            BackColor = Color.Transparent,
        };

        private List<PictureBox> IngredientsList = new List<PictureBox>()
        {
            new PictureBox() {Image = Meal.Dough,},
            new PictureBox() {Image = Meal.Tomato,},
            new PictureBox() {Image = Meal.Basil,},
            new PictureBox() {Image = Meal.Cheese,},
            new PictureBox() {Image = Meal.TomatoSauce,},
            new PictureBox() {Image = Meal.Peperoni,},
            new PictureBox() {Image = Meal.Mushroom,},
            new PictureBox() {Image = Meal.Chicken,},
        };

        private PictureBox closeRifledBoardButton = new PictureBox()
        {
            BackgroundImage = Interface.CloseButton,
            Size = Interface.CloseButton.Size,
            BackColor = Color.Transparent,
            BorderStyle = BorderStyle.None,
            Location = new Point(673,4)
        };
        private Button startButton = new Button()
        {
            Text = "Старт",
            ForeColor = Color.White,
            AutoSize = true,
            Font = new Font(FontFamily.GenericMonospace, 20),
        };
        private PictureBox buttonE = new PictureBox()
        {
            Image = Interface.ButtonE,
            Size = Interface.ButtonE.Size,
            BackColor = Color.Transparent,
        };
        private void InitializeComponent()
        {
            Name = "Pizza Master";
            Text = "Pizza Master";
            BackgroundImage = Sprites.Interface.BackgroundImage;
            game = new Model.Game(1040,704);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = menu.Size = new Size(game.Width,game.Height);
            KeyPreview = true;

            startButton.Click += (sender, args) =>
            {
                menu.Hide();
                moveTimer.Start();
                addVisitorTimer.Start();
            };
            closeRifledBoardButton.Click += (sender, args) =>
            {
                RifledBoard.Hide();
                game.Player.CanGo = true;
                Controls.Add(buttonE);
            };
            menu.Controls.Add(startButton);
            
            Controls.Add(menu);
            
            Controls.Add(buttonE);
            
            Controls.Add(RifledBoard);
            RifledBoard.Controls.Add(Ingredients);
            RifledBoard.Controls.Add(closeRifledBoardButton);
            RifledBoard.MouseDown += panelMouseDown;
            RifledBoard.MouseUp += panelMouseUp;
            RifledBoard.MouseMove += panelMouseMove;
            for (int i = 0; i < IngredientsList.Count; i++)
            {
                IngredientsList[i].BackColor = Color.Black;
                IngredientsList[i].Size =
                    new Size(Ingredients.Size.Width / IngredientsList.Count-2,Ingredients.Size.Height-1);
                IngredientsList[i].Margin = new Padding(1);
                var a = IngredientsList[i].Size - IngredientsList[i].Image.Size;
                IngredientsList[i].SizeMode = PictureBoxSizeMode.CenterImage;
                Ingredients.Controls.Add(IngredientsList[i]);
            }
            RifledBoard.Hide();
            InitializateAnimation();
            InitializateInterior();
        }

        bool a = true;
        int x, y;
        private void panelMouseDown(object sender, MouseEventArgs e)
        {
            Panel mPanel = (Panel)sender;
            x = e.X;
            y = e.Y;
            a = false;
        }
        private void panelMouseUp(object sender, MouseEventArgs e)
        {
            a = true;
        }
        private void panelMouseMove(object sender, MouseEventArgs e)
        {
            if (!a)
            {
                Panel mPanel = (Panel)sender;
                if(!game.IsInsideMap(new PointF(mPanel.Left+e.X-x,mPanel.Top+e.Y-y))
                   || !game.IsInsideMap(new PointF(mPanel.Right+e.X-x,mPanel.Bottom+e.Y-y)))
                    return;
                mPanel.Left += e.X - x;
                mPanel.Top += e.Y - y;
            }
        }
        
        private void InitializateAnimation()
        {
            ImageAnimator.Animate(Sprites.Interior.Furnace, (_, _) => Invalidate());
            ImageAnimator.Animate(Sprites.Interior.Clock, (_, _) => Invalidate());
            
            ImageAnimator.Animate(chefSprites.MoveDown, (_, _) => Invalidate());
            ImageAnimator.Animate(chefSprites.MoveUp, (_, _) => Invalidate());
            ImageAnimator.Animate(chefSprites.MoveLeft, (_, _) => Invalidate());
            ImageAnimator.Animate(chefSprites.MoveRight, (_, _) => Invalidate());
            
            ImageAnimator.Animate(visitorOneSprites.MoveDown, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorOneSprites.MoveUp, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorOneSprites.MoveLeft, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorOneSprites.MoveRight, (_, _) => Invalidate());
            
            ImageAnimator.Animate(visitorTwoSprites.MoveDown, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorTwoSprites.MoveUp, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorTwoSprites.MoveLeft, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorTwoSprites.MoveRight, (_, _) => Invalidate());
        }
        private void InitializateInterior()
        {
            game.Player = new Player(game, new Point(500, 230), 3, new Size(28, 20));
            game.Add(game.Player);
            game.RifledBoard = new RifledBoard(game, new Point(933, 112), new Size(31, 33));
            game.Add(game.RifledBoard);
            game.Furnaces.AddRange(new []
            { 
                new Furnace(game, new Point(708, 60), new Size(32, 91)),
                new Furnace(game, new Point(740, 60), new Size(32, 91)),
                new Furnace(game, new Point(789, 60), new Size(32, 91)),
                new Furnace(game, new Point(821, 60), new Size(32, 91))
            });
            game.AddRange(game.Furnaces);
            game.AddRange(new[]
            {
                //квадратные столы
                new Interior(game, new Point(94, 168), new Size(96, 32)),
                new Interior(game, new Point(94, 388), new Size(96, 32)),
                new Interior(game, new Point(94, 285), new Size(96, 32)),
                //скамейки
                new Interior(game, new Point(103, 153), new Size(79, 13)),
                new Interior(game, new Point(103, 209), new Size(79, 13)),
                new Interior(game, new Point(103, 270), new Size(79, 13)),
                new Interior(game, new Point(103, 329), new Size(79, 13)),
                new Interior(game, new Point(103, 374), new Size(79, 13)),
                new Interior(game, new Point(103, 431), new Size(79, 13)),
                //круглые столы
                new Interior(game, new Point(115, 528), new Size(63, 43)),
                new Interior(game, new Point(272, 528), new Size(63, 43)),
                new Interior(game, new Point(494, 528), new Size(63, 43)),
                new Interior(game, new Point(115+546, 528), new Size(63, 43)),
                new Interior(game, new Point(115+707, 528), new Size(63, 43)),
                //табуретки
                new Interior(game, new Point(134, 505), new Size(25, 15)),
                new Interior(game, new Point(87, 543), new Size(25, 15)),
                new Interior(game, new Point(134, 580), new Size(25, 15)),
                new Interior(game, new Point(181, 543), new Size(25, 15)),
                //
                new Interior(game, new Point(134 + 157, 505), new Size(25, 15)),
                new Interior(game, new Point(87 + 157, 543), new Size(25, 15)),
                new Interior(game, new Point(134 + 157, 580), new Size(25, 15)),
                new Interior(game, new Point(181 + 157, 543), new Size(25, 15)),
                //
                new Interior(game, new Point(134 + 379, 505), new Size(25, 15)),
                new Interior(game, new Point(87 + 379, 543), new Size(25, 15)),
                new Interior(game, new Point(134 + 379, 580), new Size(25, 15)),
                new Interior(game, new Point(181 + 379, 543), new Size(25, 15)),
                //
                new Interior(game, new Point(134 + 546, 505), new Size(25, 15)),
                new Interior(game, new Point(87 + 546, 543), new Size(25, 15)),
                new Interior(game, new Point(134 + 546, 580), new Size(25, 15)),
                new Interior(game, new Point(181 + 546, 543), new Size(25, 15)),
                //
                new Interior(game, new Point(134 + 707, 505), new Size(25, 15)),
                new Interior(game, new Point(87 + 707, 543), new Size(25, 15)),
                new Interior(game, new Point(134 + 707, 580), new Size(25, 15)),
                new Interior(game, new Point(181 + 707, 543), new Size(25, 15)),
                //стенки бара
                new Interior(game, new Point(369, 215), new Size(24, 160)),
                new Interior(game, new Point(369, 344), new Size(243, 30)),
                new Interior(game, new Point(369, 108), new Size(24, 75)),
                new Interior(game, new Point(394, 105), new Size(217, 33)),
                //стенки кухни
                new Interior(game, new Point(872, 112), new Size(92, 34)),
                new Interior(game, new Point(964, 112), new Size(31, 125)),
                new Interior(game, new Point(872, 203), new Size(92, 34)),
                //табуретки у бара
                new Interior(game, new Point(328, 146), new Size(31, 22)),
                new Interior(game, new Point(328, 233), new Size(31, 22)),
                new Interior(game, new Point(328, 277), new Size(31, 22)),
                new Interior(game, new Point(328, 320), new Size(31, 22)),
                new Interior(game, new Point(388, 382), new Size(31, 22)),
                new Interior(game, new Point(568, 382), new Size(31, 22)),
                //часы
                new Interior(game, new Point(62, 148), new Size(19, 17)),
                //стены
                new Interior(game, new Point(0, 0), new Size(36, 653)),
                new Interior(game, new Point(0, 652), new Size(376, 52)),
                new Interior(game, new Point(450, 652), new Size(590, 52)),
                new Interior(game, new Point(0, 0), new Size(1040, 134)),
                new Interior(game, new Point(995, 0), new Size(45, 704)),
                new Interior(game, new Point(611, 120), new Size(65, 125)),
                new Interior(game, new Point(611, 315), new Size(383, 100)),
                //бочки
                new Interior(game, new Point(41, 621), new Size(58, 31)),
                //пианино
                new Interior(game, new Point(224, 108), new Size(64, 46)),
                new Interior(game, new Point(245, 166), new Size(22, 6)),
                //сундуки
                new Interior(game, new Point(969, 413), new Size(24, 47)),
                new Interior(game, new Point(969, 462), new Size(24, 47)),
                new Interior(game, new Point(969, 512), new Size(24, 47)),
                //шкаф в баре
                new Interior(game, new Point(577, 161), new Size(31, 52)),
                //тумбочка
                new Interior(game,new Point(643,401),new Size(64,28)),
                new Interior(game,new Point(717,401),new Size(64,28)),
                new Interior(game,new Point(792,401),new Size(64,28)),
                //шкафчик
                new Interior(game,new Point(901,398),new Size(32,30))
            });
        }
    }
}

