using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game.Model
{
    public class GameLevel
    {
        public readonly Dictionary<Type, List<GameObject>> Objects;
        public readonly Player Player;
        public readonly Size GameSize;
        public int Width => GameSize.Width;
        public int Height => GameSize.Height;

        public GameLevel(int width = 1000,int height =500)
        {
            GameSize = new Size(width, height);
            Objects = new Dictionary<Type, List<GameObject>>();
            Player = new Player(this, new Point(500, 230), 3, new Size(32, 20));
            Objects.Add(Type.Player,new List<GameObject>{Player});
        }
        public bool IsInsideMap(PointF p) => p.X >= 0 && p.Y >= 0 && p.X <= Width && p.Y <= Height;
        
    }
}