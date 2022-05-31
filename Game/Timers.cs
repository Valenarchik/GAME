using System;
using System.Drawing;
using System.Linq;
using Model;
using System.Windows.Forms;
using Game.SpritesAndMusic;

namespace Game
{
    public partial class MyForm
    {
        public readonly Timer DayTimer = new(){Interval = 90000};
        private readonly Timer moveTimer = new() {Interval = 100};
        private readonly Timer addVisitorTimer = new() {Interval = 5000};
        private void UpdateAddVisitorTimer(object sender, EventArgs e)
        {
            if (game.Visitors.Count >= Model.Game.MaxCountVisitors || game.Random.Next(0, 2) == 0) return;
            var visitor = new Visitor(game, new Point(419, 684), 6, new Size(28, 20));
            game.Objects.Add(visitor);
            game.Visitors.Enqueue(visitor);
            visitor.GoToBar();
            Invalidate();
        }
        
        private void UpdateMoveTimer(object sender, EventArgs e)
        {
            if (game.Player.IsMoving)
                game.Player.Move(game.Player.Direction);

            foreach (var visitor in game.Visitors)
            {
                if (visitor.Out)
                {
                    game.Objects.Remove(game.Visitors.Dequeue());
                    break;
                }

                if (visitor.Track.Count != 0)
                    visitor.Move(visitor.Track.First());
                else
                    visitor.StopMove();
            }
            Invalidate();
        }
        
        private void UpdateDayTimer(object sender, EventArgs e)
        {
            game.Money -= game.Rent;
            game.Player.CanGo = false;
            Controls.Remove(buttonE);
            if (game.IsOver)
            {
                foreach (var music in Music.SoundsEffect.Concat(Music.MusicInCafe))
                    music.controls.stop();
                Music.GameOver.controls.play();
                menuBackground.Show();
                gameOver.Show();
                pizzaMaster.Hide();
                continueButton.Hide();
                newGameButton.Show();
            }
            else
            {
                rentMenu.Show();
                rentMoneyText.Text = "-" + game.Rent;
                Music.WastingCoins.controls.play();
            }
            
            DayTimer.Stop();
            addVisitorTimer.Stop();
            moveTimer.Stop();
            game.Stop();
        }
    }
}