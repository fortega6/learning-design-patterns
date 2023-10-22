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
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;
        private InGameMenuMediator _mediator;

        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartPressed);
            _backToMenuButton.onClick.AddListener(OnBackToMenuPressed);
        }
        public void Configure(InGameMenuMediator mediator)
        {
            _mediator = mediator;
        }
        public void Show()
        {
            _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        private void OnBackToMenuPressed()
        {
            _mediator.OnBackToMenuPressed();
        }
        private void OnRestartPressed()
        {
            _mediator.OnRestartPressed();
        }
    }
}
