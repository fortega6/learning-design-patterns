using Common;
using Patterns.Decoupling.ServiceLocator;
using System;

namespace Battle.GameStates
{
    class PlayingState : GameState, EventObserver
    {
        private Action<GameStateController.GameStates> _onEndCallback;
        private int _aliveShips;
        private bool _allShipSpawned;

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _onEndCallback = onEndedCallback;
            _aliveShips = 0;
            _allShipSpawned = false;
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.AllShipSpawned, this);
        }
        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveShips -= 1;
                var shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                if (shipDestroyedEventData.Team == Ships.Common.Teams.Ally)
                {
                    _onEndCallback?.Invoke(GameStateController.GameStates.GameOver);
                    return;
                }
            }
            else if (eventData.EventId == EventIds.ShipSpawned)
            {
                _aliveShips += 1;
                return;
            }
            else if (eventData.EventId == EventIds.AllShipSpawned)
            {
                _allShipSpawned = true;
                return;
            }

            CheckGameState();
        }

        private void CheckGameState()
        {
            if (_aliveShips == 0 && _allShipSpawned)
            {
                _onEndCallback?.Invoke(GameStateController.GameStates.Victory);
            }
        }
    }
}