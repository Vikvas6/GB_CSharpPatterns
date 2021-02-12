namespace SimpleArcanoid.Model
{
    public class ScoreModel : IScoreModel
    {
        public int Goal { get; set; }
        public int Current { get; set; }

        public ScoreModel(int goal)
        {
            Goal = goal;
            Current = 0;
        }
    }
}
