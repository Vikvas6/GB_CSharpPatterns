using System.Collections.Generic;
using System.Json;


namespace Asteroids
{
    public class UnitFactory : IParse
    {
        private List<IParse> factories = new List<IParse>();

        public UnitFactory()
        {
            factories.Add(new InfantryFactory());
            factories.Add(new MageFactory());
        }

        public void Parse(string toParse)
        {
            JsonArray array = (JsonArray) JsonArray.Parse(toParse);
            foreach (var item in array)
            {
                if (item.ContainsKey("unit"))
                {
                    foreach (var factory in factories)
                    {
                        factory.Parse(item["unit"]);
                    }
                }
            }
        }
    }
}
