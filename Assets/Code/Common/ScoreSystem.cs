using Core.DataStorage;
using Patterns.Structural.Adapter;
using Ships.Common;
using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class ScoreSystem : EventObserver
    {
        private readonly EventQueue _eventQueue;
        private readonly DataStore _dataStore;
        private readonly string UserData = "UserData";
        private int _currentScore;

        public ScoreSystem(DataStore dataStore)
        {
            _dataStore = dataStore;
            _eventQueue.Subscribe(EventIds.Victory, this);
            _eventQueue.Subscribe(EventIds.ShipDestroyed, this);
        }
        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                UpdateBestScore(_currentScore);
                return;
            }
            if(eventData.EventId == EventIds.Victory)
            {
                var shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                AddScore(shipDestroyedEventData);
                return;
            }
        }

        private void AddScore(ShipDestroyedEventData shipDestroyedEventData)
        {
            if (shipDestroyedEventData.Team != Teams.Enemy)
            {
                return;
            }

            _currentScore += shipDestroyedEventData.ScoreToAdd;
        }
        private void UpdateBestScore(int newScore)
        {
            var bestScore = GetBestScores();

        }
        private void SaveBestScore()
        {

        }
        public int[] GetBestScores()
        {
            var userData = _dataStore.GetData<UserData>(UserData);
            return userData.BestScores;
        }
    }
}