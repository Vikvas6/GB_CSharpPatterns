using UnityEngine;
using System.Json;

namespace Asteroids
{
    public class InfantryFactory : IParse
    {
        public void Parse(string toParse)
        {
            JsonValue root = JsonValue.Parse(toParse);
            if (root.ContainsKey("type") && root["type"] == "infantry")
            {
                var enemy = new EnemyBridge(new PhysAttack(), new Infantry(), root["health"]);
                enemy.Attack();
                enemy.Move(0, 0, Time.deltaTime);
            }
        }
    }
}
