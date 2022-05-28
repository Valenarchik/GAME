using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.SpritesAndMusic;
using Model;

namespace Game
{
    public sealed partial class MyForm
    {
        private readonly global::Model.Game game = new(1040, 704);
        private readonly ChefSprites chefSprites = new();
        private readonly VisitorOneSprites visitorOneSprites = new();
        private readonly VisitorTwoSprites visitorTwoSprites = new();
        
        public MyForm()
        {
            InitializeComponent();
            Paint += OnPaint;
            KeyDown += OnPressDown;
            KeyUp += OnPressUp;
            Furnace.OnStartCoking += () =>
            {
                Music.FireSoundPlayer.controls.play();
                Music.IronDoor.controls.play();
            };
            Furnace.OnEndCoking += () =>
            {
                Music.IronDoor.controls.play();
                Music.FireSoundPlayer.controls.stop();
            };

            DayTimer.Tick += UpdateDayTimer;
        }
        
        private void OnPressDown(object sender, KeyEventArgs e)
        {
            var player = game.Player;
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.Move(Direction.Up);
                    break;
                case Keys.A:
                    player.Move(Direction.Left);
                    break;
                case Keys.S:
                    player.Move(Direction.Down);
                    break;
                case Keys.D:
                    player.Move(Direction.Right);
                    break;
                case Keys.E:
                    if (!rifledBoard.Visible && !rentMenu.Visible)
                    {
                        player.OnCompleteOrder();
                        game.TrashBox.OnThrowOutTrash();
                        OpenRifledBoard();
                        FurnaceInteraction();
                    }
                    break;
                case Keys.Escape:
                    OpenMenu();
                    break;
            }
            Invalidate();
        }
        
        private void FurnaceInteraction()
        {
            var player = game.Player;
            if (game.Player.FindNearestFurnace())
            {
                var furnace =  player.NearestFurnace;
                if(!furnace.IsKindled)
                    furnace.StartCooking();
                else
                    furnace.EndCooking();
            }
        }
        
        private void OnPressUp(object sender, KeyEventArgs e)
        {
            game.Player.StopMove();
        }
        
        private void OpenRifledBoard()
        {
            if (!global::Model.Game.InZone(game.Player, game.RifledBoard, Player.LittleActivationRadius))
                return;
            rifledBoard.Show();
            Controls.Remove(buttonE);
            game.Player.CanGo = false;
        }

        private void PlayWalkSound()
        {
            var player = game.Player;
            if (player.IsMoving)
            {
                if (player.Position.X > 675 && player.Position.Y < 421)
                {
                    Music.WalkingOnConcrete.controls.play();
                    Music.WalkingOnWood.controls.stop();
                }
                else
                {
                    Music.WalkingOnConcrete.controls.stop();
                    Music.WalkingOnWood.controls.play();
                }
            }
            else
            {
                Music.WalkingOnConcrete.controls.stop();
                Music.WalkingOnWood.controls.stop();
            }
        }
        
        private void OnStartButtonClick(object sender, EventArgs args)
        {
            menu.Hide();
            DayTimer.Start();
            moveTimer.Start();
            addVisitorTimer.Start();
        }

        private void OpenMenu()=>menu.Show();
        
    }
}
