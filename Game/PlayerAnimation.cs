using System.Drawing;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public partial class MyForm : Form
    {
        public void PlayerAnimation(Graphics g)
        {
            if (game.Player.IsMoving)
                switch (game.Player.Direction)
                {
                    case Directions.Up:
                        DrawAnimation(g, game.Player, Sprites.Chef.MoveUp1, Sprites.Chef.StandUp, Sprites.Chef.MoveUp2,
                            Sprites.Chef.StandUp);
                        break;
                    case Directions.Right:
                        DrawAnimation(g, game.Player, Sprites.Chef.MoveRight1, Sprites.Chef.StandRight,
                            Sprites.Chef.MoveRight2, Sprites.Chef.StandRight);
                        break;
                    case Directions.Down:
                        DrawAnimation(g, game.Player, Sprites.Chef.MoveDown1, Sprites.Chef.StandDown, Sprites.Chef.MoveDown2,
                            Sprites.Chef.StandDown);
                        break;
                    case Directions.Left:
                        DrawAnimation(g, game.Player, Sprites.Chef.MoveLeft1, Sprites.Chef.StandLeft, Sprites.Chef.MoveLeft2,
                            Sprites.Chef.StandLeft);
                        break;
                }
            else
            {
                switch (game.Player.Direction)
                {
                    case Directions.Up:
                        DrawAnimation(g, game.Player, Sprites.Chef.StandUp);
                        break;
                    case Directions.Right:
                        DrawAnimation(g, game.Player, Sprites.Chef.StandRight);
                        break;
                    case Directions.Down:
                        DrawAnimation(g, game.Player, Sprites.Chef.StandDown);
                        break;
                    case Directions.Left:
                        DrawAnimation(g, game.Player, Sprites.Chef.StandLeft);
                        break;
                } 
            }
        }
        
        private void DrawAnimation (Graphics g, GameEntity gameEntity,params Image[] sprites)
        {
            if (sprites is null) return;
            g.DrawImage(sprites[time % sprites.Length], gameEntity.Position - new Size(2,2));
        }
    }
}