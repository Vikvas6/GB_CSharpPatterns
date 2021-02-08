using System;


namespace Asteroids.Iterator
{
    [Flags]
    public enum Target
    {
        None = 0,
        Unit = 1,
        Autocast = 2,
        Passive = 4,
    }
}
