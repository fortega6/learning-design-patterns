using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameMenuView : MonoBehaviour, InGameMenuMediator
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenuView _pauseMenuView;
        private CommandQueue _commandQueue;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonPressed);
            _pauseMenuView.Configure(this);
        }
        private void Start()
        {
            _commandQueue = ServiceLocator.Instance.GetService<CommandQueue>();
            HideAllMenus();
        }

        private void HideAllMenus()
        {
            _pauseMenuView.Hide();
        }

        public void OnBackToMenuPressed()
        {
            _commandQueue.AddCommand(new LoadSceneCommand("Menu"));
        }

        public void OnRestartPressed()
        {
            HideAllMenus();
            _commandQueue.AddCommand(new StopBattleCommand());
            _commandQueue.AddCommand(new StartBattleCommand());
        }

        public void OnResumePressed()
        {
            _pauseMenuView.Hide();
            ResumeGame();
        }

        private void ResumeGame()
        {
            _commandQueue.AddCommand(new ResumeGameCommand());
        }

        private void OnPauseButtonPressed()
        {
            _commandQueue.AddCommand(new PauseGameCommand());
            _pauseMenuView.Show();
        }
    }
}