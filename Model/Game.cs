using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;

namespace Model
{
    public class Game
    {
        public bool GameOver => money < 0;
        public int Rent { get; private set; } = 3;
        private int money = 20;
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

        public Player Player { get; set; }
        public RifledBoard RifledBoard { get; set; }
        public TrashBox TrashBox { get; set; }
        public readonly Queue<Visitor> Visitors = new();
        public readonly List<Furnace> Furnaces = new();
        
        public static readonly int MaxCountVisitors = 3;
        public readonly Size GameSize;
        public readonly Random Random = new();
        public int Width => GameSize.Width;
        public int Height => GameSize.Height;

        public Game(int width = 1000, int height = 500)
        {
            GameSize = new Size(width,height);
        }

        public void Add(GameObject gameObject)
        {
            switch (gameObject)
            {
                case Visitor visitor:
                    Visitors.Enqueue(visitor);
                    break;
            }

            Objects.Add(gameObject);
         
        }
        public void AddRange(IEnumerable<GameObject> enumerable)
        {
            foreach (var o in enumerable) Add(o);
        }

        public bool IsInsideMap(PointF p) => p.X >= 0 && p.Y >= 0 && p.X <= Width && p.Y <= Height;

        public static bool InZone(GameObject gameObject1, GameObject gameObject2, double radius) =>
            gameObject1.Radius + gameObject2.Radius + radius >= GetDistance(gameObject1.Centre, gameObject2.Centre);

        public static double GetDistance(PointF p1, PointF p2) =>
            Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        
        public static bool SegmentsIntersected(float r1Min, float r1Max, float r2Min, float r2Max) =>
            Math.Min(r1Max, r2Max) >= Math.Max(r1Min, r2Min);
        public static Direction ConvertOffsetToDirection(Size offset)
        {
            return offset.Width switch
            {
                < 0 when offset.Height == 0 => Direction.Left,
                > 0 when offset.Height == 0 => Direction.Right,
                0 when offset.Height < 0 => Direction.Up,
                0 when offset.Height > 0 => Direction.Down,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        public void Start()
        {
            Player = new Player(this, new Point(500, 230), 4, new Size(28, 20));
            Objects.Add(Player);
            RifledBoard = new RifledBoard(this, new Point(933, 112), new Size(31, 33));
            Objects.Add(RifledBoard);
            Furnaces.AddRange(new []
            { 
                new Furnace(this, new Point(708, 60), new Size(32, 86)),
                new Furnace(this, new Point(740, 60), new Size(32, 86)),
                new Furnace(this, new Point(789, 60), new Size(32, 86)),
                new Furnace(this, new Point(821, 60), new Size(32, 86))
            });
            Objects.AddRange(Furnaces);
            TrashBox = new TrashBox(this, new Point(840, 227), new Size(26, 16));
            Objects.Add(TrashBox);
            
            AddRange(new[]
            {
                //квадратные столы
                new Interior(this, new Point(94, 168), new Size(96, 32)),
                new Interior(this, new Point(94, 388), new Size(96, 32)),
                new Interior(this, new Point(94, 285), new Size(96, 32)),
                //скамейки
                new Interior(this, new Point(103, 153), new Size(79, 13)),
                new Interior(this, new Point(103, 209), new Size(79, 13)),
                new Interior(this, new Point(103, 270), new Size(79, 13)),
                new Interior(this, new Point(103, 329), new Size(79, 13)),
                new Interior(this, new Point(103, 374), new Size(79, 13)),
                new Interior(this, new Point(103, 431), new Size(79, 13)),
                //круглые столы
                new Interior(this, new Point(115, 528), new Size(63, 43)),
                new Interior(this, new Point(272, 528), new Size(63, 43)),
                new Interior(this, new Point(494, 528), new Size(63, 43)),
                new Interior(this, new Point(115 + 546, 528), new Size(63, 43)),
                new Interior(this, new Point(115 + 707, 528), new Size(63, 43)),
                //табуретки
                new Interior(this, new Point(134, 505), new Size(25, 15)),
                new Interior(this, new Point(87, 543), new Size(25, 15)),
                new Interior(this, new Point(134, 580), new Size(25, 15)),
                new Interior(this, new Point(181, 543), new Size(25, 15)),
                //
                new Interior(this, new Point(134 + 157, 505), new Size(25, 15)),
                new Interior(this, new Point(87 + 157, 543), new Size(25, 15)),
                new Interior(this, new Point(134 + 157, 580), new Size(25, 15)),
                new Interior(this, new Point(181 + 157, 543), new Size(25, 15)),
                //
                new Interior(this, new Point(134 + 379, 505), new Size(25, 15)),
                new Interior(this, new Point(87 + 379, 543), new Size(25, 15)),
                new Interior(this, new Point(134 + 379, 580), new Size(25, 15)),
                new Interior(this, new Point(181 + 379, 543), new Size(25, 15)),
                //
                new Interior(this, new Point(134 + 546, 505), new Size(25, 15)),
                new Interior(this, new Point(87 + 546, 543), new Size(25, 15)),
                new Interior(this, new Point(134 + 546, 580), new Size(25, 15)),
                new Interior(this, new Point(181 + 546, 543), new Size(25, 15)),
                //
                new Interior(this, new Point(134 + 707, 505), new Size(25, 15)),
                new Interior(this, new Point(87 + 707, 543), new Size(25, 15)),
                new Interior(this, new Point(134 + 707, 580), new Size(25, 15)),
                new Interior(this, new Point(181 + 707, 543), new Size(25, 15)),
                //стенки бара
                new Interior(this, new Point(369, 215), new Size(24, 160)),
                new Interior(this, new Point(369, 344), new Size(243, 30)),
                new Interior(this, new Point(369, 108), new Size(24, 75)),
                new Interior(this, new Point(394, 105), new Size(217, 33)),
                //стенки кухни
                new Interior(this, new Point(872, 112), new Size(92, 34)),
                new Interior(this, new Point(964, 112), new Size(31, 125)),
                new Interior(this, new Point(872, 203), new Size(92, 34)),
                //табуретки у бара
                new Interior(this, new Point(328, 146), new Size(31, 22)),
                new Interior(this, new Point(328, 233), new Size(31, 22)),
                new Interior(this, new Point(328, 277), new Size(31, 22)),
                new Interior(this, new Point(328, 320), new Size(31, 22)),
                new Interior(this, new Point(388, 382), new Size(31, 22)),
                new Interior(this, new Point(568, 382), new Size(31, 22)),
                //часы
                new Interior(this, new Point(62, 148), new Size(19, 17)),
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
                //пианино
                new Interior(this, new Point(224, 108), new Size(64, 46)),
                new Interior(this, new Point(245, 166), new Size(22, 6)),
                //сундуки
                new Interior(this, new Point(969, 413), new Size(24, 47)),
                new Interior(this, new Point(969, 462), new Size(24, 47)),
                new Interior(this, new Point(969, 512), new Size(24, 47)),
                //шкаф в баре
                new Interior(this, new Point(577, 161), new Size(31, 52)),
                //тумбочка
                new Interior(this, new Point(643, 401), new Size(64, 28)),
                new Interior(this, new Point(717, 401), new Size(64, 28)),
                new Interior(this, new Point(792, 401), new Size(64, 28)),
                //шкафчик
                new Interior(this, new Point(901, 398), new Size(32, 30))
            });
        }
    }
}