using System.ComponentModel;
using Game.SpritesAndMusic;

namespace Game
{
    public partial class MyForm
    {
        private void InitializationMusic()
        {
            Music.FireSoundPlayer.controls.stop();
            Music.WalkingOnWood.controls.stop();
            Music.WalkingOnConcrete.controls.stop();
            Music.TrashBox.controls.stop();
            Music.Sell.controls.stop();
            Music.TurnPage.controls.stop();
            Music.CloseBook.controls.stop();
            Music.IronDoor.controls.stop();
            Music.WastingCoins.controls.stop();
            Music.GameOver.controls.stop();
            Music.CookingPizza.controls.stop();
            
            Music.Madness.controls.stop();
            Music.JazzCafe.controls.stop();
            //Music.RestaurantMusic.controls.stop();
            
            Music.RestaurantMusic.PlayStateChange += RestaurantMusicOnPlayStateChange;
            Music.JazzCafe.PlayStateChange += JazzCafeOnPlayStateChange;
            Music.Madness.PlayStateChange += MadnessOnPlayStateChange;
        }
        
        private void RestaurantMusicOnPlayStateChange(int newState)
        {
            if (newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
                Music.JazzCafe.controls.play();
        }
        
        private void JazzCafeOnPlayStateChange(int newState)
        {
            if (newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
                Music.Madness.controls.play();
        }
        
        private void MadnessOnPlayStateChange(int newState)
        {
            if (newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
                Music.RestaurantMusic.controls.play();
        }
    }
}