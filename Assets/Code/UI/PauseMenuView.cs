using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _backToMenuButton;
        private InGameMenuMediator _mediator;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(OnResumePressed);
            _restartButton.onClick.AddListener(OnRestartPressed);
            _backToMenuButton.onClick.AddListener(OnBackToMenuButtonPressed);
        }

        public void Configure(InGameMenuMediator mediator)
        {
            _mediator = mediator;
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        private void OnBackToMenuButtonPressed()
        {
            _mediator.OnBackToMenuPressed();
        }

        private void OnResumePressed()
        {
            _mediator.OnResumePressed();
        }

        private void OnRestartPressed()
        {
            _mediator.OnRestartPressed();
        }
    }
}