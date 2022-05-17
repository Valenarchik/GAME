using System.Drawing;
using System.IO;

namespace Game
{
    public class Sprites
    {
        private static readonly string spritesFolder =
            Path.Combine
            (
                new DirectoryInfo
                (
                    Directory.GetCurrentDirectory()
                ).Parent?.Parent?.Parent?.FullName ?? string.Empty,
                "Sprites"
            );

        public abstract class Entity
        {
            protected Bitmap MoveDown1;
            protected Bitmap MoveDown2;
            protected Bitmap MoveLeft1;
            protected Bitmap MoveLeft2;
            protected Bitmap MoveRight1;
            protected Bitmap MoveRight2;
            protected Bitmap MoveUp1;
            protected Bitmap MoveUp2;
            protected Bitmap StandUp;
            protected Bitmap StandDown;
            protected Bitmap StandLeft;
            protected Bitmap StandRight;

            public Image[] MoveUpAnimation => new Image[] {MoveUp1, StandUp, MoveUp2, StandUp};
            public Image[] MoveDownAnimation => new Image[] {MoveDown1, StandDown, MoveDown2, StandDown};
            public Image[] MoveRightAnimation => new Image[] {MoveRight1, StandRight, MoveRight2, StandRight};
            public Image[] MoveLeftAnimation => new Image[] {MoveLeft1, StandLeft, MoveLeft2, StandLeft};

            public Image[] StandUpAnimation => new Image[] {StandUp};
            public Image[] StandDownAnimation => new Image[] {StandDown};
            public Image[] StandRightAnimation => new Image[] {StandRight};
            public Image[] StandLeftAnimation => new Image[] {StandLeft};
        }
        public class Chef: Entity
        {
            public Chef()
            {
                var spritesFolder = Path.Combine(Sprites.spritesFolder, "Chef");
                var move = Path.Combine(spritesFolder, "Move");
                var stand = Path.Combine(spritesFolder, "Stand");
                MoveDown1 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Down 1.png")));
                MoveDown2 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Down 2.png")));
                MoveLeft1 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Left 1.png")));
                MoveLeft2 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Left 2.png")));
                MoveRight1 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Right 1.png")));
                MoveRight2 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Right 2.png")));
                MoveUp1 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Up 1.png")));
                MoveUp2 = new Bitmap(Image.FromFile(Path.Combine(move, "Move Up 2.png")));
                StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
                StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
                StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
                StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
            }
        }

        public class VisitorOne : Entity
        {
            public VisitorOne()
            {
                var spritesFolder = Path.Combine(Sprites.spritesFolder, "NPS", "Visitor One");
                var move = Path.Combine(spritesFolder, "Move");
                var stand = Path.Combine(spritesFolder, "Stand");
                MoveDown1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Down 1.png")));
                MoveDown2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Down 2.png")));
                MoveLeft1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Left 1.png")));
                MoveLeft2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Left 2.png")));
                MoveRight1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Right 1.png")));
                MoveRight2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Right 2.png")));
                MoveUp1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Up 1.png")));
                MoveUp2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Up 2.png")));
                StandUp = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Up.png")));
                StandDown = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Down.png")));
                StandLeft = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Left.png")));
                StandRight = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Right.png")));
            }
        }
        public class VisitorTwo: Entity
        {
            public VisitorTwo()
            {
                var spritesFolder = Path.Combine(Sprites.spritesFolder, "NPS", "Visitor Two");
                var move = Path.Combine(spritesFolder, "Move");
                var stand = Path.Combine(spritesFolder, "Stand");
                MoveDown1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Down 1.png")));
                MoveDown2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Down 2.png")));
                MoveLeft1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Left 1.png")));
                MoveLeft2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Left 2.png")));
                MoveRight1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Right 1.png")));
                MoveRight2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Right 2.png")));
                MoveUp1 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Up 1.png")));
                MoveUp2 = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, move, "Move Up 2.png")));
                StandUp = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Up.png")));
                StandDown = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Down.png")));
                StandLeft = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Left.png")));
                StandRight = new Bitmap(Image.FromFile(Path.Combine(spritesFolder, stand, "Stand Right.png")));
            }
        }
        
        public class Other
        {
            public static readonly Bitmap BackgroundImage =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Background and Interface", "Background.png")));
            public static readonly Bitmap TabBar =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Background and Interface", "tabbar.png")));
        }
        
        public class Meal
        {
            public static readonly Bitmap Cheese =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "cheese.png")));
            public static readonly Bitmap Dough =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "dough.png")));
            public static readonly Bitmap Peperoni =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "pepperoni.png")));
            public static readonly Bitmap Tomato =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "tomato.png")));
        }
        
        public class Interior
        {
            public static readonly Bitmap Chest =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "chest.png")));
            public static readonly Bitmap Wardrobe =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "wardrobe.png")));
            public static readonly Bitmap Cup =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "cup.png")));
            public static readonly Bitmap Clock1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "clock1.png")));
            public static readonly Bitmap Clock2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "clock2.png")));
            public static readonly Bitmap Clock3 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "clock3.png")));
            public static readonly Bitmap Wall =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "wall.png")));
            public static readonly Bitmap Barrels =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "barrels.png")));
        }
    }
}