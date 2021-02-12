using System;
using System.Collections.Generic;
using SimpleArcanoid.Model;
using SimpleArcanoid.View;
using SimpleArcanoid.ViewModel;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SimpleArcanoid
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private PlayerView _player;
        [SerializeField] private BallView _ball;
        [SerializeField] private PauseView _pause;
        [SerializeField] private GameObject _gameoverMenu;
        [SerializeField] private GameObject _victoryMenu;
        [SerializeField] private ScoreboardView _scoreboardView;

        [SerializeField] private GameObject _barPrefab;
        [SerializeField] private GameObject _barRoot;
        
        [SerializeField] private Vector3 _ballInitialForce;
        [SerializeField] private float _playerVelocity;
        [SerializeField] private float _horizontalBoundries;
        [SerializeField] private int _barsInBottomRow;

        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private InputView _inputView;
        private bool _gameOver = false;

        private float _offsetX = 1;
        private float _offsetY = 0.5f;

        private event Action AddScorePoint;
        private event Action<int> AddGoalScorePoint;

        private void Start()
        {
            Cursor.visible = false;
            
            IPlayerModel playerModel = new PlayerModel(_playerVelocity);
            IPlayerViewModel playerViewModel = new PlayerViewModel(playerModel, _horizontalBoundries);
            _player.Init(playerViewModel);

            IBallModel ballModel = new BallModel();
            IBallViewModel ballViewModel = new BallViewModel(ballModel, _ballInitialForce, playerViewModel);
            ballViewModel.OnBallFall += GameOver;
            _ball.Init(ballViewModel);
            AddUpdatable(_ball);

            IPauseModel pauseModel = new PauseModel();
            IPauseViewModel pauseViewModel = new PauseViewModel(pauseModel);
            _pause.Init(pauseViewModel);
            
            _inputView = new InputView(playerViewModel, ballViewModel, pauseViewModel);
            AddUpdatable(_inputView);

            IScoreModel scoreModel = new ScoreModel(0);
            IScoreViewModel scoreViewModel = new ScoreViewModel(scoreModel);
            scoreViewModel.OnGetGoal += VictoryGameOver;
            
            AddScorePoint += scoreViewModel.AddPoint;
            AddGoalScorePoint += scoreViewModel.IncGoal;
            CreateField();
            _scoreboardView.Init(scoreViewModel);
            
        }

        private void Update()
        {
            for (int i = 0; i < _updatables.Count; i++)
            {
                _updatables[i].UpdateTick();
            }
        }

        private void CreateField()
        {
            for (int i = 0; i < _barsInBottomRow; i++)
            {
                CreateFieldLine(_barsInBottomRow-i, i * _offsetY);   
            }
        }

        private void CreateFieldLine(int barCounts, float y)
        {
            float startPos = 0.0f;
            if (barCounts % 2 == 0)
            {
                startPos = (-barCounts / 2 + 0.5f) * _offsetX;
            }
            else
            {
                startPos = -(barCounts - 1) / 2 * _offsetX;
            }

            for (int i = 0; i < barCounts; i++)
            {
                CreateBar(new Vector3(startPos + i * _offsetX, y, 0.0f));
            }
        }

        private void CreateBar(Vector3 initialVector)
        {
            var bar = Instantiate(_barPrefab, _barRoot.transform);
            IBarModel barModel = new BarModel(initialVector);
            IBarViewModel barViewModel = new BarViewModel(barModel);
            bar.GetComponent<BarView>().Init(barViewModel);
            barViewModel.OnInteract += () => AddScorePoint?.Invoke();
            AddGoalScorePoint?.Invoke(1);
        }

        public void AddUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            _pause.Pause(false);
            SceneManager.LoadScene(0);
        }

        public void GameEnd(GameObject menuToShow)
        {
            if (!_gameOver)
            {
                _gameOver = true;
                _pause.Pause(true);
                menuToShow.SetActive(true);
            }
        }

        public void GameOver()
        {
            GameEnd(_gameoverMenu);
        }

        public void VictoryGameOver()
        {
            GameEnd(_victoryMenu);
        }
    }
}
