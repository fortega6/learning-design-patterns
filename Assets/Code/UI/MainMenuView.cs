using System;
using System.Threading.Tasks;
using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour, MainMenuMediator
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _showLeaderboardButton;
        [SerializeField] private LeaderboardView _leaderboard;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(OnStartButtonPressed);
            _showLeaderboardButton.onClick.AddListener(OnShowLeaderboardButton);
        }

        private void Start()
        {
            _leaderboard.Configure(this);
            _leaderboard.Hide();
        }

        private void OnShowLeaderboardButton()
        {
            _leaderboard.Show();
        }
        public void OnCloseLeaderboardPressed()
        {
            _leaderboard.Hide();
        }
        private void OnStartButtonPressed()
        {
            var loadGameSceneCommand = new LoadGameSceneCommand();
            ServiceLocator.Instance.GetService<CommandQueue>()
                .AddCommand(loadGameSceneCommand);
        }
    }
}
