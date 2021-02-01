using UnityEngine;


namespace Asteroids
{
    public class EnemyBattleshipFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyBattleship>("Enemy/Battleship"));
            enemy.SetHealth(hp);
            return enemy;
        }
    }
}
