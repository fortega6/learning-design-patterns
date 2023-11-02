using Patterns.Decoupling.ServiceLocator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScoreSystem = Common.Score.ScoreSystem;

namespace UI
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private RectTransform _container;
        [SerializeField] private ScoreEntryView _scoreEntryViewPrefab;
        private List<ScoreEntryView> _scoreEntryViewInstances;
        private MainMenuMediator _mediator;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            _scoreEntryViewInstances = new List<ScoreEntryView>();
        }

        private void OnCloseButtonPressed()
        {
            _mediator.OnCloseLeaderboardPressed();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            var bestScores = ServiceLocator.Instance.GetService<ScoreSystem>().GetBestScores();
            for (var i = 0; i < bestScores.Length; i++) 
            {
                var bestScore = bestScores[i];
                if (bestScore == 0)
                {
                    continue;
                }

                var scoreEntryView = Instantiate(_scoreEntryViewPrefab, _container);
                var position = (i + 1).ToString();
                var score = bestScore.ToString();
                scoreEntryView.Confirure(position, score);
                _scoreEntryViewInstances.Add(scoreEntryView);
                Debug.Log(bestScore);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            foreach (var scoreEntryView in _scoreEntryViewInstances)
            {
                Destroy(scoreEntryView.gameObject);
            }

            _scoreEntryViewInstances.Clear();
        }

        public void Configure(MainMenuMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
