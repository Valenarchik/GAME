using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WMPLib;

namespace Game.SpritesAndMusic
{
    public static class Sprites
    {
        public static readonly string SpritesFolder =
            Path.Combine
            (
                new DirectoryInfo
                (
                    Directory.GetCurrentDirectory()
                ).Parent?.Parent?.Parent?.FullName ?? string.Empty,
                "SpritesAndMusic"
            );

        public static Size EntitySpriteSize = new Size(48, 64);

        public static Bitmap LoadImage (string spritesFolder, string name) =>
            new(Image.FromFile(Path.Combine(spritesFolder, name)));
        public static Bitmap LoadAnimation (string spritesFolder, string name) =>
            new(Path.Combine(spritesFolder, name));
    }
    

    public static class Music
    {
        private static readonly string musicFolder = Path.Combine(Sprites.SpritesFolder, "Music");

        private static int musicVolume = 10;
        private static int soundEffectVolume = 50;
        public static int MusicVolume
        {
            get => musicVolume;
            set
            {
                musicVolume = value;
                foreach (var e in MusicInCafe)
                    e.settings.volume = value;
            }
        }

        public static int SoundEffectVolume
        {
            get => soundEffectVolume;
            set
            {
                soundEffectVolume = value;
                foreach (var e in SoundsEffect)
                    e.settings.volume = value;
            }
        }

        public static readonly WindowsMediaPlayer Madness = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder, "Madness.wav"),
            uiMode = "invisible",
            volume = MusicVolume,
        };

        public static readonly WindowsMediaPlayer JazzCafe = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"jazz-cafe.mp3"),
            uiMode = "invisible",
            volume = MusicVolume
        };
        
        public static readonly WindowsMediaPlayer RestaurantMusic = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"restaurant-music.mp3"),
            uiMode = "invisible",
            volume = MusicVolume
        };

        public static readonly WindowsMediaPlayer WalkingOnConcrete = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder, "WalkingOnConcrete.mp3"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        
        public static readonly WindowsMediaPlayer WalkingOnWood = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder, "WalkingOnWood.mp3"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        
        public static readonly WindowsMediaPlayer FireSoundPlayer = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder, "FireSound.wav"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        
        public static readonly WindowsMediaPlayer TrashBox = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder, "TrashBox.wav"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };

        public static readonly WindowsMediaPlayer Sell = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"sell_buy_item.wav"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        public static readonly WindowsMediaPlayer TurnPage = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"turn_page.wav"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        public static readonly WindowsMediaPlayer CloseBook = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"bookClosing.wav"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        public static readonly WindowsMediaPlayer IronDoor = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"IronDoor.mp3"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        public static readonly WindowsMediaPlayer WastingCoins = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"wasting coins.mp3"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        
        public static readonly WindowsMediaPlayer GameOver = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"GameOver.mp3"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        
        public static readonly WindowsMediaPlayer CookingPizza = new WindowsMediaPlayerClass()
        {
            URL = Path.Combine(musicFolder,"CookingPizza.mp3"),
            uiMode = "invisible",
            volume = SoundEffectVolume,
        };
        
        public static readonly List<WindowsMediaPlayer> SoundsEffect = new()
        {
            WalkingOnConcrete,
            WalkingOnWood,
            FireSoundPlayer,
            TrashBox,
            Sell,
            TurnPage,
            CloseBook,
            IronDoor,
            WastingCoins,
            CookingPizza,
            GameOver
        };

        public static readonly List<WindowsMediaPlayer> MusicInCafe = new()
        {
            Madness,
            JazzCafe,
            RestaurantMusic,
        };


    }

    public abstract class EntitySprites
    {
        public Bitmap MoveUp;
        public Bitmap MoveRight;
        public Bitmap MoveDown;
        public Bitmap MoveLeft;

        public Bitmap StandUp;
        public Bitmap StandRight;
        public Bitmap StandDown;
        public Bitmap StandLeft;
    }

    public class ChefSprites : EntitySprites
    {
        public ChefSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "Chef");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = Sprites.LoadAnimation(move, "Move Down.gif");
            MoveLeft = Sprites.LoadAnimation(move, "Move Left.gif");
            MoveRight = Sprites.LoadAnimation(move, "Move Right.gif");
            MoveUp = Sprites.LoadAnimation(move, "Move Up.gif");
            StandUp = Sprites.LoadImage(stand, "Stand Up.png");
            StandDown = Sprites.LoadImage(stand, "Stand Down.png");
            StandLeft = Sprites.LoadImage(stand, "Stand Left.png");
            StandRight = Sprites.LoadImage(stand, "Stand Right.png");
        }
    }

    public class VisitorOneSprites : EntitySprites
    {
        
        public VisitorOneSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "NPS","Visitor One");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = Sprites.LoadAnimation(move, "Move Down.gif");
            MoveLeft = Sprites.LoadAnimation(move, "Move Left.gif");
            MoveRight = Sprites.LoadAnimation(move, "Move Right.gif");
            MoveUp = Sprites.LoadAnimation(move, "Move Up.gif");
            StandUp = Sprites.LoadImage(stand, "Stand Up.png");
            StandDown = Sprites.LoadImage(stand, "Stand Down.png");
            StandLeft = Sprites.LoadImage(stand, "Stand Left.png");
            StandRight = Sprites.LoadImage(stand, "Stand Right.png");
        }
    }

    public class VisitorTwoSprites : EntitySprites
    {
        public VisitorTwoSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "NPS","Visitor Two");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = Sprites.LoadAnimation(move, "Move Down.gif");
            MoveLeft = Sprites.LoadAnimation(move, "Move Left.gif");
            MoveRight = Sprites.LoadAnimation(move, "Move Right.gif");
            MoveUp = Sprites.LoadAnimation(move, "Move Up.gif");
            StandUp = Sprites.LoadImage(stand, "Stand Up.png");
            StandDown = Sprites.LoadImage(stand, "Stand Down.png");
            StandLeft = Sprites.LoadImage(stand, "Stand Left.png");
            StandRight = Sprites.LoadImage(stand, "Stand Right.png");
        }
    }

    public static class Interface
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Background and Interface");
        private static Bitmap LoadImage(string name) => Sprites.LoadImage(spritesFolder, name);
        private static Bitmap LoadAnimation(string name) => Sprites.LoadAnimation(spritesFolder, name);
        
        public static readonly Bitmap Ok = LoadImage("Ok.png");
        public static readonly Bitmap Dream = LoadImage("Dream.png");
        public static readonly Bitmap BackgroundImage = LoadImage("Background.png");
        public static readonly Bitmap RifledBoard = LoadImage("RifledBoard.png");
        public static readonly Bitmap CloseButton = LoadImage("closeButton.png");
        public static readonly Bitmap TabBar = LoadImage("tabbar.png");
        public static readonly Bitmap Coin = LoadImage("Coin.png");

        public static readonly Bitmap MenuBackground = LoadImage("MenuBackground.png");
        public static readonly Bitmap MenuTab = LoadImage("MenuTab.png");
        public static readonly Bitmap PizzaMaster = LoadImage("PizzaMaster.png");

        public static readonly Bitmap Book = LoadImage("Book.png");
        public static readonly Bitmap Recipes = LoadImage("Recipes.png");
        public static readonly Bitmap RentMenu = LoadImage("RentMenu.png");

        public static readonly Bitmap ArrowBack = LoadImage("ArrowBack.png");
        public static readonly Bitmap CloseGuide = LoadImage("CloseGuide.png");
        public static readonly Bitmap ForwardArrow = LoadImage("ForwardArrow.png");
        public static readonly Bitmap Guide1 = LoadImage("Guide1.png");
        public static readonly Bitmap Guide2 = LoadImage("Guide2.png");
        
        public static readonly Bitmap GameOver = LoadImage("GameOver.png");
        
        public static readonly Bitmap ButtonE = LoadAnimation ("buttonE.gif");


        private static readonly string loadSpritesFolder = Path.Combine(spritesFolder, "Load");
        private static Bitmap LoadLoadImage(string name) => Sprites.LoadImage(loadSpritesFolder, name);

        public static readonly List<Bitmap> Load = new()
        {
            LoadLoadImage("Load1.png"),
            LoadLoadImage("Load2.png"),
            LoadLoadImage("Load3.png"),
            LoadLoadImage("Load4.png"),
            LoadLoadImage("Load5.png"),
            LoadLoadImage("Load6.png"),
            LoadLoadImage("Load7.png")
        };
    }

    public static class Meal
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Meal");
        private static Bitmap LoadImage(string name) => Sprites.LoadImage(spritesFolder, name);

        public static readonly Bitmap Steam = LoadImage("Steam.png");

        public static readonly Bitmap Cheese = LoadImage("Cheese.png");
        public static readonly Bitmap Dough = LoadImage("Dough.png");
        public static readonly Bitmap Pepperoni = LoadImage("Pepperoni.png");
        public static readonly Bitmap Tomato = LoadImage("Tomato.png");
        public static readonly Bitmap TomatoSauce = LoadImage("TomatoSauce.png");
        public static readonly Bitmap Basil = LoadImage("Basil.png");
        public static readonly Bitmap Mushroom = LoadImage("Mushroom.png");
        public static readonly Bitmap Chicken = LoadImage("Chicken.png");

        public static readonly Bitmap BigCheese = LoadImage("BigCheese.png");
        public static readonly Bitmap BigDough = LoadImage("BigDough.png");
        public static readonly Bitmap BigPepperoni = LoadImage("BigPepperoni.png");
        public static readonly Bitmap BigTomato = LoadImage("BigTomato.png");
        public static readonly Bitmap BigTomatoSauce = LoadImage("BigTomatoSauce.png");
        public static readonly Bitmap BigBasil = LoadImage("BigBasil.png");
        public static readonly Bitmap BigMushroom = LoadImage("BigMushroom.png");
        public static readonly Bitmap BigChicken = LoadImage("BigChicken.png");

        public static readonly Bitmap PizzaDiabola = LoadImage("PizzaDiabola.png");
        public static readonly Bitmap PizzaGreen = LoadImage("PizzaGreens.png");
        public static readonly Bitmap PizzaMargaret = LoadImage("PizzaMargaret.png");
        public static readonly Bitmap PizzaPepperoni = LoadImage("PizzaPepperoni.png");
        public static readonly Bitmap BurntPizza = LoadImage("BurntPizza.png");

        public static readonly Bitmap BigPizzaDiabola = LoadImage("BigPizzaDiabola.png");
        public static readonly Bitmap BigPizzaGreen = LoadImage("BigPizzaGreens.png");
        public static readonly Bitmap BigPizzaMargaret = LoadImage("BigPizzaMargaret.png");
        public static readonly Bitmap BigPizzaPepperoni = LoadImage("BigPizzaPepperoni.png");
    }

    public static class Interior
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Interior");
        private static Bitmap LoadAnimation(string name) => Sprites.LoadAnimation(spritesFolder, name);
        private static Bitmap LoadImage(string name) => Sprites.LoadImage(spritesFolder, name); 

        public static readonly Bitmap Clock = LoadAnimation("clock.gif");
        public static readonly Bitmap Furnace = LoadAnimation( "furnaceTypeOne.gif");
        public static readonly Bitmap Flashlight = LoadAnimation( "flashlight.gif");

        public static readonly Bitmap Wardrobe = LoadImage( "wardrobe.png");
        public static readonly Bitmap Cup = LoadImage( "cup.png");
        public static readonly Bitmap Wall = LoadImage( "wall.png");
        public static readonly Bitmap Barrels = LoadImage( "barrels.png");
        public static readonly Bitmap TrashBox = LoadImage( "TrashBox.png");
    }
}