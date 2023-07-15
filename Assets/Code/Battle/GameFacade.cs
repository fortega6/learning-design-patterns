using System;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameStateController _gameStateController; 

        public void StartBattle()
        {
            _gameStateController.Reset();
            ScoreView.Instance.Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            LoadingScreen.Instance.Hide();
        }

        public void StopBattle()
        {
            LoadingScreen.Instance.Show();
            _enemySpawner.StopAndReset();
        }
    }
}