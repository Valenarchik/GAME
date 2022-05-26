using System.Drawing;
using Game.Model;

namespace Game
{
    public partial class MyForm
    { 
        private void InitializationGameObjects()
        {
            game.Player = new Player(game, new Point(500, 230), 3, new Size(28, 20));
            game.Add(game.Player);
            game.RifledBoard = new RifledBoard(game, new Point(933, 112), new Size(31, 33));
            game.Add(game.RifledBoard);
            game.Furnaces.AddRange(new []
            { 
                new Furnace(game, new Point(708, 60), new Size(32, 86),2),
                new Furnace(game, new Point(740, 60), new Size(32, 86),2),
                new Furnace(game, new Point(789, 60), new Size(32, 86),2),
                new Furnace(game, new Point(821, 60), new Size(32, 86),2)
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