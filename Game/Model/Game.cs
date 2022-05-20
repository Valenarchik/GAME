using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game.Model
{
    public class Game
    {
        public readonly List<GameObject> Objects = new();
        public readonly Dictionary<TypeInterior, List<Interior>> Interiors  = new();
        public Player Player { get; private set; }
        public readonly Queue<Visitor> Visitors = new();
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
                case Player player:
                    Player = player;
                    break;
                case Visitor visitor:
                    Visitors.Enqueue(visitor);
                    break;
                case Interior interior:
                {
                    if (!Interiors.ContainsKey(interior.Type))
                        Interiors[interior.Type] = new List<Interior>();
                    Interiors[interior.Type].Add(interior);
                    break;
                }
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
    }
}