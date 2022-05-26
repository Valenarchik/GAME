using System;
using System.Collections.Generic;
using System.Drawing;
using Game.Sprites;

namespace Game.Model
{
    public class Game
    {
        public bool GameOver => money < 0;
        private int money;
        public int Money
        {
            get => money;
            set
            {
                money = value;
                OnMoneyChange();
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

        protected virtual void OnMoneyChange()
        {
            MoneyChange?.Invoke();
        }
        
    }
}