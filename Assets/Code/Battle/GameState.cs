using Common;
using System;
using UnityEditor;
using UnityEngine;

namespace Battle
{
    public class GameState : MonoBehaviour, EventObserver
    {
        private enum GameStates
        {
            Playing,
            GameOver,
            Victory
        }

        [SerializeField] private GameFacade _gameFacade;

        private int _aliveShips;
        private bool _allShipSpawned;
        private GameStates _currentState;

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Unsubscribe(EventIds.AllShipSpawned, this);
        }

        public void Reset()
        {
            _currentState = GameStates.Playing;
            _aliveShips = 0;
            _allShipSpawned = false;
        }

        public void Process(EventData eventData)
        {
            if (_currentState != GameStates.Playing)
            {
                return;
            }

            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveShips -= 1;
                var shipDestroyedEventData = (ShipDestroyedEvenData)eventData;
                if (shipDestroyedEventData.Team == Ships.Common.Teams.Ally)
                {
                    _currentState = GameStates.GameOver;
                    _gameFacade.StopBattle();
                    EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
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
                _gameFacade.StopBattle();
                _currentState = GameStates.Victory;
                Debug.Log("Victory");
                EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
            }
        }
    }
}