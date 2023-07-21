using Battle;
using Common;
using Common.Commands;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _backToMenuButton.onClick.AddListener(BackToMenu);
        }

        private void Start()
        {
            gameObject.SetActive(false);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.GameOver, this);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.GameOver, this);
        }
        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                .AddCommand(new StartBattleCommand());
            gameObject.SetActive(false);
        }
        private void BackToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                .AddCommand(new LoadSceneCommand("Menu"));
        }
    }
}
