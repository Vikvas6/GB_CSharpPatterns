using System;
using Asteroids.Object_Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    public class CreateEnemyFacade
    {
        public Enemy CreateEnemy(Transform playerTransform, float _enemyDistance)
        {
            var enemy = ServiceLocator.Resolve<EnemyPool>().GetRandomEnemy();
            var angle = Random.Range(0, 90);
            Vector3 direction3D = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0.0f);
            enemy.transform.position = playerTransform.localPosition + direction3D * _enemyDistance;
            enemy.gameObject.SetActive(true);
            return enemy;
        }
    }
}
