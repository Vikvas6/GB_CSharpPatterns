using UnityEngine;


namespace SimpleArcanoid.Model
{
    public interface IBarModel
    {
        bool Active { get; set;  }
        Vector3 Position { get; set; }
    }
}
