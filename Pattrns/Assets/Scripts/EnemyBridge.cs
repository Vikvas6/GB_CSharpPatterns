namespace Asteroids
{
    public class EnemyBridge
    {
        private readonly IAttack _attack;
        private readonly IMove _move;
        private int _hp;

        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }

        public EnemyBridge(IAttack attack, IMove move, int hp)
        {
            _attack = attack;
            _move = move;
            _hp = hp;
        }

        public EnemyBridge(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
            _hp = 100;
        }

        public void Attack()
        {
            _attack.Attack();
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical,deltaTime);
        }
    }

}