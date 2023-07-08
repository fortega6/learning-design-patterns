using Battle;
using Common;
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
        [SerializeField] private GameFacade _gameFacade;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void Start()
        {
            gameObject.SetActive(false);
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
        }
        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.GameOver, this);
        }
        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                var shipDestroyedEventData = (ShipDestroyedEvenData)eventData;
                if (shipDestroyedEventData.Team == Ships.Common.Teams.Ally)
                {
                    _gameFacade.StopBattle();
                    EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
                }
                return;
            }

            if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
        private void RestartGame()
        {
            _gameFacade.StartBattle();
            gameObject.SetActive(false);
        }
    }
}
