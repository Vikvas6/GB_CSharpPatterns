using System;
using Asteroids.Object_Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class CreateEnemyFacade
    {
        public Enemy CreateEnemy(Transform playerTransform, float enemyDistance)
        {
            var enemy = ServiceLocator.Resolve<EnemyPool>().GetRandomEnemy();
            var angle = Random.Range(0, 90);
            Vector3 direction3D = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0.0f);
            enemy.transform.position = playerTransform.localPosition + direction3D * enemyDistance;
            enemy.gameObject.SetActive(true);
            enemy.AddInteractable(new DamageController(enemy, enemy.Health.Max));
            return enemy;
        }
    }
}
