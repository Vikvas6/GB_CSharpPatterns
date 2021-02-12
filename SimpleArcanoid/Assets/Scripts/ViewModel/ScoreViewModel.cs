using System;
using SimpleArcanoid.Model;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public class ScoreViewModel : IScoreViewModel
    {
        private readonly IScoreModel _scoreModel;

        public event Action<int> OnScoreChanged;
        public event Action OnGetGoal;

        public ScoreViewModel(IScoreModel scoreModel)
        {
            _scoreModel = scoreModel;
        }
        
        public int GetGoalScore()
        {
            return _scoreModel.Goal;
        }

        public void AddPoint()
        {
            _scoreModel.Current++;
            OnScoreChanged?.Invoke(_scoreModel.Current);
            CheckGoal();
        }

        public void IncGoal(int inc)
        {
            _scoreModel.Goal += inc;
        }

        private void CheckGoal()
        {
            if (_scoreModel.Current >= _scoreModel.Goal)
            {
                OnGetGoal?.Invoke();
            }
        }

    }

}