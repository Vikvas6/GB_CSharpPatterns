namespace Asteroids.ChainOfResponsibility
{
    public class BulletForceModifier : PlayerModifier
    {
        private int _forceMultiplier;
        
        public BulletForceModifier(Player player, int forceMultiplier) : base(player)
        {
            _forceMultiplier = forceMultiplier;
        }

        public override void Handle()
        {
            _player.MultiplyForce(_forceMultiplier);
            base.Handle();
        }
    }
}
