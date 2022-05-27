using System.Drawing;
using System.Windows.Forms;
using Model;
using Game.SpritesAndMusic;

namespace Game
{
    public partial class MyForm : Form
    {
        private readonly Size mixingEntityAnimations = new(Sprites.EntitySpriteSize.Width * 10 / 45,
            Sprites.EntitySpriteSize.Height * 7 / 10);

        private void EntityAnimation(Graphics g, GameEntity entity, EntitySprites sprites)
        {
            if (entity.IsMoving)
                switch (entity.Direction)
                {
                    case Direction.Up:
                        g.DrawImage(sprites.MoveUp, entity.Position - mixingEntityAnimations);
                        break;
                    case Direction.Right:
                        g.DrawImage(sprites.MoveRight, entity.Position - mixingEntityAnimations);
                        break;
                    case Direction.Down:
                        g.DrawImage(sprites.MoveDown, entity.Position - mixingEntityAnimations);
                        break;
                    case Direction.Left:
                        g.DrawImage(sprites.MoveLeft, entity.Position - mixingEntityAnimations);
                        break;
                }
            else
            {
                switch (entity.Direction)
                {
                    case Direction.Up:
                        g.DrawImage(sprites.StandUp, entity.Position - mixingEntityAnimations);
                        break;
                    case Direction.Right:
                        g.DrawImage(sprites.StandRight, entity.Position - mixingEntityAnimations);
                        break;
                    case Direction.Down:
                        g.DrawImage(sprites.StandDown, entity.Position - mixingEntityAnimations);
                        break;
                    case Direction.Left:
                        g.DrawImage(sprites.StandLeft, entity.Position - mixingEntityAnimations);
                        break;
                }
            }
        }
    }
}