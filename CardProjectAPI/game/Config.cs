namespace CardProjectAPI.game
{
    /// <summary>
    /// Used to load all game config
    /// </summary>
    public class Config
    {
        public readonly int CardDropCooldown;

        public Config(int CardDropCoolDown)
        {
            this.CardDropCooldown = CardDropCoolDown;
            Game.CheckFiles();
        }


    }
}
