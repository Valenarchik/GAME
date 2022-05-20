using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;

namespace Game
{
    public partial class MyForm : Form
    {
        private readonly Size mixingEntityAnimations = new(Sprites.Sprites.EntitySpriteSize.Width*10/45,
            Sprites.Sprites.EntitySpriteSize.Height*7/10);
        private void EntityAnimation(Graphics g, GameEntity entity, Sprites.EntitySprites sprites)
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
            var currentSprite = sprites[numberSprite % sprites.Length];
            g.DrawImage(currentSprite, gameObject.Position-mixingEntityAnimations);
        }
    }
}