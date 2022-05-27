using System.Drawing;
using Game.SpritesAndMusic;

namespace Game
{
    public partial class MyForm
    {
        private void InitializationAnimation()
        {
            ImageAnimator.Animate(Interior.Furnace, (_, _) => Invalidate());
            ImageAnimator.Animate(Interior.Clock, (_, _) => Invalidate());

            ImageAnimator.Animate(chefSprites.MoveDown, (_, _) => Invalidate());
            ImageAnimator.Animate(chefSprites.MoveUp, (_, _) => Invalidate());
            ImageAnimator.Animate(chefSprites.MoveLeft, (_, _) => Invalidate());
            ImageAnimator.Animate(chefSprites.MoveRight, (_, _) => Invalidate());
            
            ImageAnimator.Animate(visitorOneSprites.MoveDown, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorOneSprites.MoveUp, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorOneSprites.MoveLeft, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorOneSprites.MoveRight, (_, _) => Invalidate());
            
            ImageAnimator.Animate(visitorTwoSprites.MoveDown, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorTwoSprites.MoveUp, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorTwoSprites.MoveLeft, (_, _) => Invalidate());
            ImageAnimator.Animate(visitorTwoSprites.MoveRight, (_, _) => Invalidate());
        }
    }
}