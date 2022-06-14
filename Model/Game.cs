using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;

namespace Model
{
    public class Game
    {
        public bool IsOver => money < 0;
        public int Rent { get; private set; } = 3;
        public const int PricePizza = 7;
        public const int PriceIngredients = 1;
        private const int StartMoneyCount = 20;
        public readonly Point StartPlayerPosition = new Point(500, 230);
        private int money;
        public int Money
        {
            get => money;
            set
            {
                money = value;
                MoneyChange?.Invoke();;
            }
        }

        public event Action MoneyChange;
        public readonly List<GameObject> Objects = new();

        public readonly Dictionary<PizzaType, List<Ingredient>> Recipes = new()
        {
            {PizzaType.Greens, new List<Ingredient> {Ingredient.Dough, Ingredient.Cheese, Ingredient.Basil, Ingredient.ChickenFillet}},
            {PizzaType.Pepperoni, new List<Ingredient> {Ingredient.Dough, Ingredient.Cheese, Ingredient.Pepperoni, Ingredient.TomatoSauce}},
            {PizzaType.Margaret, new List<Ingredient> {Ingredient.Dough, Ingredient.Cheese, Ingredient.Tomato, Ingredient.ChickenFillet}},
            {PizzaType.Diabola, new List<Ingredient> {Ingredient.Dough, Ingredient.Cheese, Ingredient.Mushroom, Ingredient.TomatoSauce}},
        };

        public Player Player { get; private set; }
        public RifledBoard RifledBoard { get; private set; }
        public TrashBox TrashBox { get; private set; }
        public readonly Queue<Visitor> Visitors = new();
        public readonly List<Furnace> Furnaces = new();
        
        public const int MaxCountVisitors = 3;
        public readonly Size GameSize;
        public readonly Random Random = new();
        public int Width => GameSize.Width;
        public int Height => GameSize.Height;
        
        public bool IsInsideMap(PointF p) => p.X >= 0 && p.Y >= 0 && p.X <= Width && p.Y <= Height;

        public static bool InZone(GameObject gameObject1, GameObject gameObject2, double radius) =>
            gameObject1.Radius + gameObject2.Radius + radius >= GetDistance(gameObject1.Centre, gameObject2.Centre);

        public static double GetDistance(PointF p1, PointF p2) =>
            Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        
        public static bool SegmentsIntersected(float r1Min, float r1Max, float r2Min, float r2Max) =>
            Math.Min(r1Max, r2Max) >= Math.Max(r1Min, r2Min);
        
        public void Restart()
        {
            Player.ToDefault();
            foreach (var visitor in Visitors)
                Objects.Remove(visitor);
            Visitors.Clear();
            foreach (var furnace in Furnaces)
                furnace.ToDefault();
            RifledBoard.ToDefault();
            Money = StartMoneyCount;
        }

        public void Stop()
        {
            foreach (var furnace in Furnaces)
                furnace.Timer.Stop();
        }

        public void Start()
        {
            foreach (var furnace in Furnaces)
                furnace.Timer.Start();
        }

        public Game(int width = 1000, int height = 500)
        {
            var squareTableSize = new Size(96, 32);
            var benchesSize = new Size(79, 13);
            var roundTableSize = new Size(63, 43);
            var stoolsSize = new Size(25, 15);
            var furnaceSize = new Size(32, 86);
            var chairSize = new Size(31, 22);
            var chestsSize = new Size(24, 47);
            var bedsideTableSize = new Size(64, 28);

            GameSize = new Size(width, height);
            Money = StartMoneyCount;
            Player = new Player(this, StartPlayerPosition, 4, new Size(28, 20));
            Objects.Add(Player);
            RifledBoard = new RifledBoard(this, new Point(933, 112), new Size(31, 33));
            Objects.Add(RifledBoard);
            Furnaces.AddRange(new[]
            {
                new Furnace(this, new Point(708, 60), furnaceSize),
                new Furnace(this, new Point(740, 60), furnaceSize),
                new Furnace(this, new Point(789, 60), furnaceSize),
                new Furnace(this, new Point(821, 60), furnaceSize)
            });
            Objects.AddRange(Furnaces);
            TrashBox = new TrashBox(this, new Point(840, 227), new Size(26, 16));
            Objects.Add(TrashBox);
            Objects.AddRange(new[]
            {
                //квадратные столы
                new Interior(this, new Point(94, 168), squareTableSize),
                new Interior(this, new Point(94, 388), squareTableSize),
                new Interior(this, new Point(94, 285), squareTableSize),
                //скамейки
                new Interior(this, new Point(103, 153), benchesSize),
                new Interior(this, new Point(103, 209), benchesSize),
                new Interior(this, new Point(103, 270), benchesSize),
                new Interior(this, new Point(103, 329), benchesSize),
                new Interior(this, new Point(103, 374), benchesSize),
                new Interior(this, new Point(103, 431), benchesSize),
                //круглые столы
                new Interior(this, new Point(115, 528), roundTableSize),
                new Interior(this, new Point(272, 528), roundTableSize),
                new Interior(this, new Point(494, 528), roundTableSize),
                new Interior(this, new Point(661, 528), roundTableSize),
                new Interior(this, new Point(822, 528), roundTableSize),
                //табуретки
                new Interior(this, new Point(134, 505),stoolsSize),
                new Interior(this, new Point(87, 543), stoolsSize),
                new Interior(this, new Point(134, 580), stoolsSize),
                new Interior(this, new Point(181, 543), stoolsSize),
                //
                new Interior(this, new Point(134 + 157, 505), stoolsSize),
                new Interior(this, new Point(87 + 157, 543), stoolsSize),
                new Interior(this, new Point(134 + 157, 580), stoolsSize),
                new Interior(this, new Point(181 + 157, 543), stoolsSize),
                //
                new Interior(this, new Point(134 + 379, 505), stoolsSize),
                new Interior(this, new Point(87 + 379, 543),  stoolsSize),
                new Interior(this, new Point(134 + 379, 580), stoolsSize),
                new Interior(this, new Point(181 + 379, 543), stoolsSize),
                //
                new Interior(this, new Point(134 + 546, 505), stoolsSize),
                new Interior(this, new Point(87 + 546, 543),  stoolsSize),
                new Interior(this, new Point(134 + 546, 580), stoolsSize),
                new Interior(this, new Point(181 + 546, 543), stoolsSize),
                //
                new Interior(this, new Point(134 + 707, 505), stoolsSize),
                new Interior(this, new Point(87 + 707, 543),  stoolsSize),
                new Interior(this, new Point(134 + 707, 580), stoolsSize),
                new Interior(this, new Point(181 + 707, 543), stoolsSize),
                //табуретки у бара
                new Interior(this, new Point(328, 146), chairSize),
                new Interior(this, new Point(328, 233), chairSize),
                new Interior(this, new Point(328, 277), chairSize),
                new Interior(this, new Point(328, 320), chairSize),
                new Interior(this, new Point(388, 382), chairSize),
                new Interior(this, new Point(568, 382), chairSize),
                //тумбочки
                new Interior(this, new Point(643, 401), bedsideTableSize),
                new Interior(this, new Point(717, 401), bedsideTableSize),
                new Interior(this, new Point(792, 401), bedsideTableSize),
                //сундуки
                new Interior(this, new Point(969, 413), chestsSize),
                new Interior(this, new Point(969, 462), chestsSize),
                new Interior(this, new Point(969, 512), chestsSize),
                //стенки бара
                new Interior(this, new Point(369, 215), new Size(24, 160)),
                new Interior(this, new Point(369, 344), new Size(243, 30)),
                new Interior(this, new Point(369, 108), new Size(24, 75)),
                new Interior(this, new Point(394, 105), new Size(217, 33)),
                //стенки кухни
                new Interior(this, new Point(872, 112), new Size(92, 34)),
                new Interior(this, new Point(964, 112), new Size(31, 125)),
                new Interior(this, new Point(872, 203), new Size(92, 34)),
                //стены
                new Interior(this, new Point(0, 0), new Size(36, 653)),
                new Interior(this, new Point(0, 652), new Size(376, 52)),
                new Interior(this, new Point(450, 652), new Size(590, 52)),
                new Interior(this, new Point(0, 0), new Size(1040, 134)),
                new Interior(this, new Point(995, 0), new Size(45, 704)),
                new Interior(this, new Point(611, 120), new Size(65, 125)),
                new Interior(this, new Point(611, 315), new Size(383, 100)),
                //бочки
                new Interior(this, new Point(41, 621), new Size(58, 31)),
                //часы
                new Interior(this, new Point(62, 148), new Size(19, 17)),
                //пианино
                new Interior(this, new Point(224, 108), new Size(64, 46)),
                new Interior(this, new Point(245, 166), new Size(22, 6)),
                //шкаф в баре
                new Interior(this, new Point(577, 161), new Size(31, 52)),
                //шкафчик
                new Interior(this, new Point(901, 398), new Size(32, 30))
            });
        }
    }
}