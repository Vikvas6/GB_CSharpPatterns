using UnityEngine;


namespace SimpleArcanoid.Model
{
    public class BarModel : IBarModel
    {
        public bool Active { get; set; }
        public Vector3 Position { get; set; }

        public BarModel(Vector3 position)
        {
            Active = true;
            Position = position;
        }
    }
}
