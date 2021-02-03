using UnityEngine;
using System.Json;

namespace Asteroids
{
    public class MageFactory : IParse
    {
        public void Parse(string toParse)
        {
            JsonValue root = JsonValue.Parse(toParse);
            if (root.ContainsKey("type") && root["type"] == "mag")
            {
                var enemy = new EnemyBridge(new MagicalAttack(), new StayMove(), root["health"]);
                enemy.Attack();
                enemy.Move(0, 0, Time.deltaTime);
            }
        }
    }
}