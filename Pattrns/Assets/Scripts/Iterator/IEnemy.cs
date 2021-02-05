using System.Collections;
using System.Collections.Generic;


namespace Asteroids.Iterator
{
    public interface IEnemy
    {
        IAbility this[int index] { get; }
        string this[Target index] { get; }
        int MaxDamage { get; }
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility();
        IEnumerable<IAbility> GetAbility(DamageType index);
    }
}
