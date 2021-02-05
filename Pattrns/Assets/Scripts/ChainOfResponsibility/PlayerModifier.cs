namespace Asteroids.ChainOfResponsibility
{
    public class PlayerModifier
    {
        protected Player _player;
        protected PlayerModifier Next;

        public PlayerModifier(Player player)
        {
            _player = player;
        }

        public void Add(PlayerModifier pm)
        {
            if (Next != null)
            {
                Next.Add(pm);
            }
            else
            {
                Next = pm;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}