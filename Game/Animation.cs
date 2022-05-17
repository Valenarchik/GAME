using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public partial class MyForm : Form
    {
        private void EntityAnimation(Graphics g, GameEntity entity, Sprites.Entity sprites)
        {
            if (entity.IsMoving)
                switch (entity.Direction)
                {
                    case Direction.Up:
                        DrawAnimation(g, entity, sprites.MoveUpAnimation);
                        break;
                    case Direction.Right:
                        DrawAnimation(g, entity, sprites.MoveRightAnimation);
                        break;
                    case Direction.Down:
                        DrawAnimation(g, entity, sprites.MoveDownAnimation);
                        break;
                    case Direction.Left:
                        DrawAnimation(g, entity, sprites.MoveLeftAnimation);
                        break;
                }
            else
            {
                switch (entity.Direction)
                {
                    case Direction.Up:
                        DrawAnimation(g, entity, sprites.StandUpAnimation);
                        break;
                    case Direction.Right:
                        DrawAnimation(g, entity, sprites.StandRightAnimation);
                        break;
                    case Direction.Down:
                        DrawAnimation(g, entity, sprites.StandDownAnimation);
                        break;
                    case Direction.Left:
                        DrawAnimation(g, entity, sprites.StandLeftAnimation);
                        break;
                }
            }
        }
        private void DrawAnimation (Graphics g, GameObject gameObject, params Image[] sprites)
        {
            if (sprites is null) return;
            var currentSprite = sprites[time % sprites.Length];
            var size = new Size(currentSprite.Size.Width*10/45,currentSprite.Size.Height*7/10);
            g.DrawImage(currentSprite, gameObject.Position-size);
        }
    }
}