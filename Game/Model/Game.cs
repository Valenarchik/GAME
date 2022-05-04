using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Game.Model
{
    public class Game
    {
        public List<GameObject> Objects { get; private set; }
        public Dictionary<TypeInterior, List<Interior>> Interiors { get; private set; }
        public  Player Player { get; private set; }
        
        public readonly Size GameSize;
        public int Width => GameSize.Width;
        public int Height => GameSize.Height;

        public Game(int width = 1000,int height =500)
        {
            GameSize = new Size(width, height);
            Objects = new List<GameObject>();
            Interiors = new Dictionary<TypeInterior, List<Interior>>();
        }

        public void Add(GameObject gameObject)
        {
            if(gameObject is Player player)
                Player = player;
            
            if(gameObject is Interior interior)
            {
                if (!Interiors.ContainsKey(interior.Type))
                    Interiors[interior.Type] = new List<Interior>();
                Interiors[interior.Type].Add(interior);
            }
            
            Objects.Add(gameObject);
        }

        public void AddRange(IEnumerable<GameObject> enumerable)
        {
            foreach (var o in enumerable) Add(o);
        }
        public bool IsInsideMap(PointF p) => p.X >= 0 && p.Y >= 0 && p.X <= Width && p.Y <= Height;

        public static bool InZone(GameObject gameObject1, GameObject gameObject2, double radius) =>
            gameObject1.Radius + gameObject2.Radius + radius >= GetDistance(gameObject1.Centre,gameObject2.Centre);

        public static bool SegmentsIntersected(float r1Min, float r1Max, float r2Min, float r2Max) =>
            Math.Min(r1Max, r2Max) >= Math.Max(r1Min, r2Min);
        
        public static double GetDistance(PointF p1, PointF p2) =>
            Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
    }
}