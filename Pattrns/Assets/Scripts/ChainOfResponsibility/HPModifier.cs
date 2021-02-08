namespace Asteroids.ChainOfResponsibility
{
    public class HPModifier : PlayerModifier
    {
        private int _hp;

        public HPModifier(Player player, int hp) : base(player)
        {
            _hp = hp;
        }

        public override void Handle()
        {
            _player.Hp += _hp;
            base.Handle();
        }
    }
}
