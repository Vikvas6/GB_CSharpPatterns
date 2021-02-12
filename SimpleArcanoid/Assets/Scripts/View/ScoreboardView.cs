using SimpleArcanoid.ViewModel;
using UnityEngine;
using UnityEngine.UI;


namespace SimpleArcanoid.View
{
    public class ScoreboardView : MonoBehaviour
    {
        private IScoreViewModel _scoreViewModel;
        private Text _board;
        private string _scoreTemplate = "Goal: %1\nPoints: %2";
        
        public void Init(IScoreViewModel scoreViewModel)
        {
            _scoreViewModel = scoreViewModel;
            _board = GetComponent<Text>();
            _scoreViewModel.OnScoreChanged += ShowCurrentScore;
            ShowCurrentScore(0);
        }

        public void ShowCurrentScore(int score)
        {
            _board.text = _scoreTemplate.Replace("%1", _scoreViewModel.GetGoalScore().ToString())
                .Replace("%2", score.ToString());
        }
    }
}
