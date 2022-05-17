using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Game.Model
{
    public class Game
    { 
        public List<GameObject> Objects => new();
        public Dictionary<TypeInterior, List<Interior>> Interiors => new();
        public Player Player { get; private set; }
        
        public readonly Queue<Visitor> Visitors = new();
        public readonly int MaxCountVisitors = 3;

        public readonly Point MeetingPoint = new(486, 386);
        
        public readonly MapSell[,] Map;
            
        public int Width => Map.GetLength(0);
        public int Height => Map.GetLength(1);

        public Game(int width = 1000, int height = 500)
        {
            Map = new MapSell[width, height];
        }

        public void Add(GameObject gameObject)
        {
            switch (gameObject)
            {
                case Player player:
                    Player = player;
                    //AddToMap(player,MapSell.Player);
                    break;
                case Visitor visitor:
                    Visitors.Enqueue(visitor);
                    //AddToMap(visitor,MapSell.Visitor);
                    break;
                case Interior interior:
                {
                    if (!Interiors.ContainsKey(interior.Type))
                        Interiors[interior.Type] = new List<Interior>();
                    Interiors[interior.Type].Add(interior);
                    //AddToMap(gameObject,MapSell.Interior);
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
        public void AddToMap(GameObject gameObject, MapSell sell)
        {
            var right = Math.Max(gameObject.Position.X, 0);
            var left = Math.Min(gameObject.Position.X + gameObject.Size.Width, Width);
            var up = Math.Max(gameObject.Position.Y, 0);
            var button = Math.Min(gameObject.Position.Y + gameObject.Size.Height, Height);
            for (var i = right; i < left; i++)
            for (var j = up; j < button; j++)
                Map[i, j] = sell;
        }
        public static Direction ConvertOffsetToDirection(Size offset)
        {
            return offset.Width switch
            {
                < 0 when offset.Height == 0 => Direction.Left,
                > 0 when offset.Height == 0 => Direction.Right,
                0 when offset.Height < 0 => Direction.Up,
                0 when offset.Height > 0 => Direction.Down,
                _ => throw new ArgumentException()
            };
        }
    }
}