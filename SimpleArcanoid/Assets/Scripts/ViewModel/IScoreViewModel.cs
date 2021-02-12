using System;


namespace SimpleArcanoid.ViewModel
{
    public interface IScoreViewModel
    {
        int GetGoalScore();
        void AddPoint();
        void IncGoal(int inc);
        event Action<int> OnScoreChanged;
        event Action OnGetGoal;
    }

}