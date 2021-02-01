using System.IO;
using UnityEngine;


namespace Asteroids
{
    public class ExampleFactories : MonoBehaviour
    {
        public void Start()
        {
            UnitFactory factory = new UnitFactory();
            using (StreamReader r = new StreamReader("enemies.json"))
            {
                string enemies = r.ReadToEnd();
                factory.Parse(enemies);
            }

        }
    }
}
