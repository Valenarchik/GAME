using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Game.Model;
namespace Game
{
    sealed partial class MyForm
    {
        private Panel menu;
        private Button startButton;
        private Button addVisitorButton;
        private Button deleteVisitorButton;
        private void InitializeComponent()
        {
            Name = "Pizza Master";
            Text = "Pizza Master";
            BackgroundImage = Sprites.Other.BackgroundImage;
            game = new Model.Game(1040,704);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = new Size(game.Width,game.Height);
            KeyPreview = true;
            menu = new Panel() {Location = new Point(0, 0),
                Size = ClientSize,
                BackColor = Color.Black};
            startButton = new Button(){Text = "Старт",
                ForeColor = Color.White,
                Size = ClientSize/4,
                Font = new Font(FontFamily.GenericMonospace,20 )};
            startButton.Location = new Point(ClientSize / 2 - startButton.Size / 2);
            startButton.Click += new EventHandler(OnStartButtonClick);
            menu.Controls.Add(startButton);
            Controls.Add(menu);

            addVisitorButton = new Button()
            {
                Location = new Point(50, 50),
                Size = new Size(120, 60),
                Text = "Добавить посетителя",
                BackColor = Color.Black,
                ForeColor = Color.Azure,
            };
            addVisitorButton.Click += (_, _) =>
            {
                game.Add(new Visitor(game, new Point(415, 685), 6, new Size(28, 20)));
            };
            Controls.Add(addVisitorButton);
            
            deleteVisitorButton = new Button()
            {
                Location = new Point(220, 50),
                Size = new Size(120, 60),
                Text = "Удалить посетителя",
                BackColor = Color.Black,
                ForeColor = Color.Azure,
            };
            deleteVisitorButton.Click += (_, _) =>
            {
                game.Objects.Remove(game.Visitors.Dequeue());
            };
            Controls.Add(deleteVisitorButton);
            InitializateInterior();
            
        }

        private void InitializateInterior()
        {
            game.Add(new Player(game, new Point(500, 230), 3, new Size(28, 20)));
           
            game.AddRange(new[]
            {
                //квадратные столы
                new Interior(game, new Point(94, 168), new Size(96, 32),TypeInterior.Table),
                new Interior(game, new Point(94, 388), new Size(96, 32),TypeInterior.Table),
                new Interior(game, new Point(94, 285), new Size(96, 32),TypeInterior.Table),
                //скамейки
                new Interior(game, new Point(103, 153), new Size(79, 13),TypeInterior.Bench),
                new Interior(game, new Point(103, 209), new Size(79, 13),TypeInterior.Bench),
                new Interior(game, new Point(103, 270), new Size(79, 13),TypeInterior.Bench),
                new Interior(game, new Point(103, 329), new Size(79, 13),TypeInterior.Bench),
                new Interior(game, new Point(103, 374), new Size(79, 13),TypeInterior.Bench),
                new Interior(game, new Point(103, 431), new Size(79, 13),TypeInterior.Bench),
                //круглые столы
                new Interior(game, new Point(115, 528), new Size(63, 43),TypeInterior.Table),
                new Interior(game, new Point(272, 528), new Size(63, 43),TypeInterior.Table),
                new Interior(game, new Point(494, 528), new Size(63, 43),TypeInterior.Table),
                new Interior(game, new Point(115+546, 528), new Size(63, 43),TypeInterior.Table),
                new Interior(game, new Point(115+707, 528), new Size(63, 43),TypeInterior.Table),
                //табуретки
                new Interior(game, new Point(134, 505), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(87, 543), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(134, 580), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(181, 543), new Size(25, 15),TypeInterior.Chair),
                //
                new Interior(game, new Point(134 + 157, 505), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(87 + 157, 543), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(134 + 157, 580), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(181 + 157, 543), new Size(25, 15),TypeInterior.Chair),
                //
                new Interior(game, new Point(134 + 379, 505), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(87 + 379, 543), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(134 + 379, 580), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(181 + 379, 543), new Size(25, 15),TypeInterior.Chair),
                //
                new Interior(game, new Point(134 + 546, 505), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(87 + 546, 543), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(134 + 546, 580), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(181 + 546, 543), new Size(25, 15),TypeInterior.Chair),
                //
                new Interior(game, new Point(134 + 707, 505), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(87 + 707, 543), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(134 + 707, 580), new Size(25, 15),TypeInterior.Chair),
                new Interior(game, new Point(181 + 707, 543), new Size(25, 15),TypeInterior.Chair),
                //стенки бара
                new Interior(game, new Point(369, 215), new Size(24, 160),TypeInterior.Wall),
                new Interior(game, new Point(369, 344), new Size(243, 30),TypeInterior.Wall),
                new Interior(game, new Point(369, 108), new Size(24, 75),TypeInterior.Wall),
                new Interior(game, new Point(394, 105), new Size(217, 33),TypeInterior.Wall),
                //стенки кухни
                new Interior(game, new Point(872, 112), new Size(92, 34),TypeInterior.Wall),
                new Interior(game, new Point(964, 112), new Size(31, 125),TypeInterior.Wall),
                new Interior(game, new Point(872, 203), new Size(92, 34),TypeInterior.Wall),
                //табуретки у бара
                new Interior(game, new Point(328, 146), new Size(31, 22),TypeInterior.Chair),
                new Interior(game, new Point(328, 233), new Size(31, 22),TypeInterior.Chair),
                new Interior(game, new Point(328, 277), new Size(31, 22),TypeInterior.Chair),
                new Interior(game, new Point(328, 320), new Size(31, 22),TypeInterior.Chair),
                new Interior(game, new Point(388, 382), new Size(31, 22),TypeInterior.Chair),
                new Interior(game, new Point(568, 382), new Size(31, 22),TypeInterior.Chair),
                //часы
                new Interior(game, new Point(62, 148), new Size(19, 17),TypeInterior.Clock),
                //стены
                new Interior(game, new Point(0, 0), new Size(36, 653),TypeInterior.Wall),
                new Interior(game, new Point(0, 652), new Size(376, 52),TypeInterior.Wall),
                new Interior(game, new Point(450, 652), new Size(590, 52),TypeInterior.Wall),
                new Interior(game, new Point(0, 0), new Size(1040, 134),TypeInterior.Wall),
                new Interior(game, new Point(995, 0), new Size(45, 704),TypeInterior.Wall),
                new Interior(game, new Point(611, 120), new Size(65, 125),TypeInterior.Wall),
                new Interior(game, new Point(611, 315), new Size(383, 100),TypeInterior.Wall),
                //печки
                new Interior(game, new Point(709, 107), new Size(64, 34),TypeInterior.Furnace),
                new Interior(game, new Point(789, 107), new Size(64, 34),TypeInterior.Furnace),
                //бочки
                new Interior(game, new Point(41, 621), new Size(58, 31),TypeInterior.Barrels),
                //пианино
                new Interior(game, new Point(224, 108), new Size(64, 46),TypeInterior.Piano),
                new Interior(game, new Point(245, 166), new Size(22, 6),TypeInterior.Chair),
                //сундуки
                new Interior(game, new Point(969, 413), new Size(24, 47),TypeInterior.Chest),
                new Interior(game, new Point(969, 462), new Size(24, 47),TypeInterior.Chest),
                new Interior(game, new Point(969, 512), new Size(24, 47),TypeInterior.Chest),
                //шкаф в баре
                new Interior(game, new Point(577, 161), new Size(31, 52),TypeInterior.Wardrobe),
                //тумбочка
                new Interior(game,new Point(643,401),new Size(64,28),TypeInterior.Wardrobe),
                new Interior(game,new Point(717,401),new Size(64,28),TypeInterior.Wardrobe),
                new Interior(game,new Point(792,401),new Size(64,28),TypeInterior.Wardrobe),
                //шкафчик
                new Interior(game,new Point(901,398),new Size(32,30),TypeInterior.Wardrobe)
            });
        }
    }
}

