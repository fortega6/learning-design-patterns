using Common;
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
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Unsubscribe(EventIds.AllShipSpawned, this);
        }
        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveShips -= 1;
                var shipDestroyedEventData = (ShipDestroyedEvenData)eventData;
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