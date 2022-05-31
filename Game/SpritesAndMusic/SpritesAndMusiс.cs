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

        private static int SoundEffectVolume
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
            MoveDown = new Bitmap(Path.Combine(move, "Move Down.gif"));
            MoveLeft = new Bitmap(Path.Combine(move, "Move Left.gif"));
            MoveRight = new Bitmap(Path.Combine(move, "Move Right.gif"));
            MoveUp = new Bitmap(Path.Combine(move, "Move Up.gif"));
            StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
            StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
            StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
            StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
        }
    }

    public class VisitorOneSprites : EntitySprites
    {
        public VisitorOneSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "NPS","Visitor One");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = new Bitmap(Path.Combine(move, "Move Down.gif"));
            MoveLeft = new Bitmap(Path.Combine(move, "Move Left.gif"));
            MoveRight = new Bitmap(Path.Combine(move, "Move Right.gif"));
            MoveUp = new Bitmap(Path.Combine(move, "Move Up.gif"));
            StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
            StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
            StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
            StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
        }
    }

    public class VisitorTwoSprites : EntitySprites
    {
        public VisitorTwoSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "NPS","Visitor Two");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = new Bitmap(Path.Combine(move, "Move Down.gif"));
            MoveLeft = new Bitmap(Path.Combine(move, "Move Left.gif"));
            MoveRight = new Bitmap(Path.Combine(move, "Move Right.gif"));
            MoveUp = new Bitmap(Path.Combine(move, "Move Up.gif"));
            StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
            StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
            StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
            StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
        }
    }

    public static class Interface
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Background and Interface");
        
        public static readonly Bitmap Ok = new(Image.FromFile(Path.Combine(spritesFolder, "Ok.png")));
        public static readonly Bitmap Dream = new(Image.FromFile(Path.Combine(spritesFolder, "Dream.png")));
        public static readonly Bitmap BackgroundImage = new(Image.FromFile(Path.Combine(spritesFolder, "Background.png")));
        public static readonly Bitmap RifledBoard = new (Image.FromFile(Path.Combine(spritesFolder, "RifledBoard.png")));
        public static readonly Bitmap CloseButton = new (Image.FromFile(Path.Combine(spritesFolder, "closeButton.png")));
        public static readonly Bitmap TabBar = new(Image.FromFile(Path.Combine(spritesFolder, "tabbar.png")));
        public static readonly Bitmap Coin = new(Image.FromFile(Path.Combine(spritesFolder, "Coin.png")));
        
        public static readonly Bitmap MenuBackground = new(Image.FromFile(Path.Combine(spritesFolder, "MenuBackground.png")));
        public static readonly Bitmap MenuTab = new(Image.FromFile(Path.Combine(spritesFolder, "MenuTab.png")));
        public static readonly Bitmap PizzaMaster = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaMaster.png")));
        
        public static readonly Bitmap Book = new(Image.FromFile(Path.Combine(spritesFolder, "Book.png")));
        public static readonly Bitmap Recipes = new(Image.FromFile(Path.Combine(spritesFolder, "Recipes.png")));
        public static readonly Bitmap RentMenu = new(Image.FromFile(Path.Combine(spritesFolder, "RentMenu.png")));
        
        public static readonly Bitmap ArrowBack = new(Image.FromFile(Path.Combine(spritesFolder, "ArrowBack.png")));
        public static readonly Bitmap CloseGuide = new(Image.FromFile(Path.Combine(spritesFolder, "CloseGuide.png")));
        public static readonly Bitmap ForwardArrow = new(Image.FromFile(Path.Combine(spritesFolder, "ForwardArrow.png")));
        public static readonly Bitmap Guide1 = new(Image.FromFile(Path.Combine(spritesFolder, "Guide1.png")));
        public static readonly Bitmap Guide2 = new(Image.FromFile(Path.Combine(spritesFolder, "Guide2.png")));
        
        public static readonly Bitmap GameOver = new(Image.FromFile(Path.Combine(spritesFolder, "GameOver.png")));
        
        public static readonly Bitmap ButtonE = new(Path.Combine(spritesFolder, "buttonE.gif"));
        public static readonly Bitmap BookAnimation = new(Path.Combine(spritesFolder, "BookAnimation.gif"));


        private static  readonly string loadSpritesFolder = Path.Combine(spritesFolder, "Load");
        public static readonly List<Bitmap> Load = new()
        {
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load1.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load2.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load3.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load4.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load5.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load6.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load7.png")))
        };
    }

    public static class Meal
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Meal");
        
        public static readonly Bitmap Steam = new(Image.FromFile(Path.Combine(spritesFolder, "Steam.png")));
        
        public static readonly Bitmap Cheese = new(Image.FromFile(Path.Combine(spritesFolder, "Cheese.png")));
        public static readonly Bitmap Dough = new(Image.FromFile(Path.Combine(spritesFolder, "Dough.png")));
        public static readonly Bitmap Pepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "Pepperoni.png")));
        public static readonly Bitmap Tomato = new(Image.FromFile(Path.Combine(spritesFolder, "Tomato.png")));
        public static readonly Bitmap TomatoSauce = new(Image.FromFile(Path.Combine(spritesFolder, "TomatoSauce.png")));
        public static readonly Bitmap Basil = new(Image.FromFile(Path.Combine(spritesFolder, "Basil.png")));
        public static readonly Bitmap Mushroom = new(Image.FromFile(Path.Combine(spritesFolder, "Mushroom.png")));
        public static readonly Bitmap Chicken = new(Image.FromFile(Path.Combine(spritesFolder, "Chicken.png")));
        
        public static readonly Bitmap BigCheese = new(Image.FromFile(Path.Combine(spritesFolder, "BigCheese.png")));
        public static readonly Bitmap BigDough = new(Image.FromFile(Path.Combine(spritesFolder, "BigDough.png")));
        public static readonly Bitmap BigPepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "BigPepperoni.png")));
        public static readonly Bitmap BigTomato = new(Image.FromFile(Path.Combine(spritesFolder, "BigTomato.png")));
        public static readonly Bitmap BigTomatoSauce = new(Image.FromFile(Path.Combine(spritesFolder, "BigTomatoSauce.png")));
        public static readonly Bitmap BigBasil = new(Image.FromFile(Path.Combine(spritesFolder, "BigBasil.png")));
        public static readonly Bitmap BigMushroom = new(Image.FromFile(Path.Combine(spritesFolder, "BigMushroom.png")));
        public static readonly Bitmap BigChicken = new(Image.FromFile(Path.Combine(spritesFolder, "BigChicken.png")));
        
        public static readonly Bitmap PizzaDiabola = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaDiabola.png")));
        public static readonly Bitmap PizzaGreen = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaGreens.png")));
        public static readonly Bitmap PizzaMargaret = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaMargaret.png")));
        public static readonly Bitmap PizzaPepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaPepperoni.png")));
        public static readonly Bitmap BurntPizza = new(Image.FromFile(Path.Combine(spritesFolder, "BurntPizza.png")));
        
        public static readonly Bitmap BigPizzaDiabola = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaDiabola.png")));
        public static readonly Bitmap BigPizzaGreen = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaGreens.png")));
        public static readonly Bitmap BigPizzaMargaret = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaMargaret.png")));
        public static readonly Bitmap BigPizzaPepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaPepperoni.png")));
    }

    public static class Interior
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Interior");

        public static readonly Bitmap Clock = new(Path.Combine(spritesFolder, "clock.gif"));
        public static readonly Bitmap Furnace = new(Path.Combine(spritesFolder, "furnaceTypeOne.gif"));
        public static readonly Bitmap Flashlight = new(Path.Combine(spritesFolder, "flashlight.gif"));

        public static readonly Bitmap Wardrobe = new(Image.FromFile(Path.Combine(spritesFolder, "wardrobe.png")));
        public static readonly Bitmap Cup = new(Image.FromFile(Path.Combine(spritesFolder, "cup.png")));
        public static readonly Bitmap Wall = new(Image.FromFile(Path.Combine(spritesFolder, "wall.png")));
        public static readonly Bitmap Barrels = new(Image.FromFile(Path.Combine(spritesFolder, "barrels.png")));
        public static readonly Bitmap TrashBox = new(Image.FromFile(Path.Combine(spritesFolder, "TrashBox.png")));
    }
}